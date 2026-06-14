using System.Buffers;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Collections.Concurrent;
using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization
{
    public class ChainSynchronizationClientService(IChainSynchronizationMessageHandlers messageHandlers, IIntersectionService intersectionService, IBlockService blockService) : IChainSynchronizationClientService
    {
        /// <summary>
        /// The active session's message queue. Re-created on every <see cref="ResumeAsync"/>
        /// so a new session never consumes messages queued by a previous session.
        /// </summary>
        public BlockingCollection<PooledWebSocketMessage> MessageQueue { get; private set; } = new(boundedCapacity: 1000);

        private readonly IChainSynchronizationMessageHandlers _messageHandlers = messageHandlers ?? throw new ArgumentNullException(nameof(messageHandlers));
        private readonly IIntersectionService _intersectionService = intersectionService ?? throw new ArgumentNullException(nameof(intersectionService));
        private readonly IBlockService _blockService = blockService ?? throw new ArgumentNullException(nameof(blockService));

        private readonly object _sessionLock = new();
        private CancellationTokenSource? _sessionCts;
        private List<Task> _sessionTasks = new();
        private List<Domain.InteractionContext> _sessionContexts = new();

        public async Task ResumeListeningAsync(Domain.InteractionContext interactionContext, CancellationToken cancellationToken)
        {
            await ResumeListeningAsync(interactionContext, MessageQueue, cancellationToken).ConfigureAwait(false);
        }

        private async Task ResumeListeningAsync(
            Domain.InteractionContext interactionContext,
            BlockingCollection<PooledWebSocketMessage> messageQueue,
            CancellationToken cancellationToken)
        {
            var buffer = ArrayPool<byte>.Shared.Rent(65536);
            using var messageStream = new MemoryStream();

            try
            {
                while (!cancellationToken.IsCancellationRequested && interactionContext.Socket.State == WebSocketState.Open)
                {
                    try
                    {
                        var receiveBuffer = new ArraySegment<byte>(buffer, 0, Math.Min(buffer.Length, 65536));
                        var result = await interactionContext.Socket.ReceiveAsync(receiveBuffer, cancellationToken);

                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            messageStream.Write(buffer, 0, result.Count);

                            if (result.EndOfMessage)
                            {
                                var messageLength = (int)messageStream.Length;
                                var messageBuffer = ArrayPool<byte>.Shared.Rent(messageLength);
                                _ = messageStream.TryGetBuffer(out var streamBuffer);
                                Buffer.BlockCopy(streamBuffer.Array!, streamBuffer.Offset, messageBuffer, 0, messageLength);

                                messageQueue.Add(new PooledWebSocketMessage(messageBuffer, messageLength, interactionContext), cancellationToken);
                                messageStream.SetLength(0);
                            }
                        }
                        else if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await ShutdownAsync(interactionContext).ConfigureAwait(false);
                            break;
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (WebSocketException webSocketException)
                    {
                        Console.WriteLine($"WebSocket error: {webSocketException.Message}");

                        if (interactionContext.Socket.State != WebSocketState.Open) break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error: {ex.Message}");
                    }
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        public async Task ProcessMessagesAsync(int maxBlocksPerSecond, CancellationToken cancellationToken)
        {
            await ProcessMessagesAsync(MessageQueue, maxBlocksPerSecond, cancellationToken).ConfigureAwait(false);
        }

        private async Task ProcessMessagesAsync(
            BlockingCollection<PooledWebSocketMessage> messageQueue,
            int maxBlocksPerSecond,
            CancellationToken cancellationToken)
        {
            var minIntervalBetweenRequests = maxBlocksPerSecond > 0
                ? TimeSpan.FromSeconds(1.0 / maxBlocksPerSecond)
                : TimeSpan.Zero;
            var requestStopwatch = Stopwatch.StartNew();

            try
            {
                foreach (var message in messageQueue.GetConsumingEnumerable(cancellationToken))
                {
                    if (minIntervalBetweenRequests > TimeSpan.Zero)
                    {
                        var elapsed = requestStopwatch.Elapsed;
                        if (elapsed < minIntervalBetweenRequests)
                        {
                            await Task.Delay(minIntervalBetweenRequests - elapsed, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    // Replenish the pipeline before handler work so in-flight requests stay high
                    // even when RollForwardHandler/RollBackwardHandler is slow.
                    await RequestNextBlockAsync(message.Context).ConfigureAwait(false);
                    requestStopwatch.Restart();

                    try
                    {
                        await ProcessBlockMessageAsync(message.Memory).ConfigureAwait(false);
                    }
                    finally
                    {
                        message.Return();
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Processing cancelled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing messages: {ex.Message}.");
            }
        }

        private async Task ProcessBlockMessageAsync(ReadOnlyMemory<byte> messageBytes)
        {
            try
            {
                await _blockService.HandleNextBlockAsync(messageBytes, _messageHandlers).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing block message: {ex.Message}.");
            }
        }

        public async Task<List<StartingPointConfiguration>> ResumeAsync(List<Domain.InteractionContext> interactionContexts, int maxBlocksPerSecond, int inFlight = 100, CancellationToken cancellationToken = default)
        {
            await ShutdownSessionAsync().ConfigureAwait(false);

            CancellationTokenSource sessionCts;
            BlockingCollection<PooledWebSocketMessage> sessionQueue;
            lock (_sessionLock)
            {
                sessionCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                sessionQueue = new BlockingCollection<PooledWebSocketMessage>(boundedCapacity: 1000);
                _sessionCts = sessionCts;
                MessageQueue = sessionQueue;
                _sessionContexts = interactionContexts.ToList();
            }
            var sessionToken = sessionCts.Token;

            foreach (var context in interactionContexts)
            {
                await CreatePointFromCurrentTipAsync(context, context.StartingPoint).ConfigureAwait(false);
            }

            var tasks = new List<Task>
            {
                Task.Run(() => ProcessMessagesAsync(sessionQueue, maxBlocksPerSecond, sessionToken), CancellationToken.None),
            };

            foreach (var context in interactionContexts)
            {
                tasks.Add(Task.Run(() => ResumeListeningAsync(context, sessionQueue, sessionToken), CancellationToken.None));
            }

            lock (_sessionLock)
            {
                _sessionTasks = tasks;
            }

            foreach (var context in interactionContexts)
            {
                for (int i = 0; i < inFlight; i++)
                {
                    await RequestNextBlockAsync(context).ConfigureAwait(false);
                }
            }

            return interactionContexts.Select(x => x.StartingPoint).ToList();
        }

        public async Task ShutdownSessionAsync()
        {
            CancellationTokenSource? cts;
            List<Task> tasks;
            List<Domain.InteractionContext> contexts;

            lock (_sessionLock)
            {
                cts = _sessionCts;
                tasks = _sessionTasks;
                contexts = _sessionContexts;
                _sessionCts = null;
                _sessionTasks = new List<Task>();
                _sessionContexts = new List<Domain.InteractionContext>();
            }

            if (cts is null && tasks.Count == 0) return;

            try { cts?.Cancel(); }
            catch (ObjectDisposedException) { }

            foreach (var context in contexts)
            {
                try { await ShutdownAsync(context).ConfigureAwait(false); }
                catch { /* socket already dead */ }
            }

            if (tasks.Count > 0)
            {
                try { await Task.WhenAll(tasks).WaitAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false); }
                catch { /* best-effort */ }
            }

            cts?.Dispose();
        }

        private async Task RequestNextBlockAsync(Domain.InteractionContext interactionContext)
        {
            try
            {
                var requestId = Guid.NewGuid();
                await _blockService.GetNextBlockAsync(interactionContext, new MirrorOptions { Id = requestId.ToString() }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error requesting next block: {ex.Message}.");
            }
        }

        public async Task ShutdownAsync(Domain.InteractionContext interactionContext)
        {
            if (interactionContext.Socket.State == WebSocketState.Open)
            {
                await interactionContext.Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None).ConfigureAwait(false);
            }
        }

        public async Task<Generated.Ogmios.TipOrOrigin> CreatePointFromCurrentTipAsync(Domain.InteractionContext context, StartingPointConfiguration startingPoint)
        {
            ArgumentNullException.ThrowIfNull(context);

            var intersection = await _intersectionService.FindIntersectionAsync(context, startingPoint).ConfigureAwait(false);
            var tip = intersection.Result.Tip.AsTip;

            return tip;
        }
    }
}
