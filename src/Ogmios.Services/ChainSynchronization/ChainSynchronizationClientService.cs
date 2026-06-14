using System.Collections.Concurrent;
using System.Buffers;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Threading.Channels;
using Ogmios.Domain;
using Microsoft.Extensions.Logging;

namespace Ogmios.Services.ChainSynchronization
{
    public class ChainSynchronizationClientService(
        IChainSynchronizationMessageHandlers messageHandlers,
        IIntersectionService intersectionService,
        IBlockService blockService,
        ILogger<ChainSynchronizationClientService>? logger = null) : IChainSynchronizationClientService
    {
        private const int HandlerQueueCapacity = 2000;
        private const int ReceiveBufferSize = 65536;

        /// <summary>
        /// The active session's message queue. Re-created on every <see cref="ResumeAsync"/>
        /// so a new session never consumes messages queued by a previous session.
        /// </summary>
        public BlockingCollection<PooledWebSocketMessage> MessageQueue { get; private set; } = new(boundedCapacity: 1000);

        private readonly IChainSynchronizationMessageHandlers _messageHandlers = messageHandlers ?? throw new ArgumentNullException(nameof(messageHandlers));
        private readonly IIntersectionService _intersectionService = intersectionService ?? throw new ArgumentNullException(nameof(intersectionService));
        private readonly IBlockService _blockService = blockService ?? throw new ArgumentNullException(nameof(blockService));
        private readonly ILogger<ChainSynchronizationClientService>? _logger = logger;

        private readonly object _sessionLock = new();
        private CancellationTokenSource? _sessionCts;
        private List<Task> _sessionTasks = new();
        private List<Domain.InteractionContext> _sessionContexts = new();
        private ChannelWriter<ChainSyncBlockWork>? _handlerQueueWriter;

        public async Task ResumeListeningAsync(Domain.InteractionContext interactionContext, CancellationToken cancellationToken)
        {
            await ResumeListeningAsync(interactionContext, MessageQueue, cancellationToken).ConfigureAwait(false);
        }

        private async Task ResumeListeningAsync(
            Domain.InteractionContext interactionContext,
            BlockingCollection<PooledWebSocketMessage> messageQueue,
            CancellationToken cancellationToken)
        {
            var receiveScratch = ArrayPool<byte>.Shared.Rent(ReceiveBufferSize);
            byte[]? messageBuffer = null;
            var messageLength = 0;

            try
            {
                while (!cancellationToken.IsCancellationRequested && interactionContext.Socket.State == WebSocketState.Open)
                {
                    try
                    {
                        var result = await interactionContext.Socket.ReceiveAsync(
                            new ArraySegment<byte>(receiveScratch, 0, ReceiveBufferSize),
                            cancellationToken).ConfigureAwait(false);

                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            EnsureMessageCapacity(ref messageBuffer, ref messageLength, result.Count);
                            Buffer.BlockCopy(receiveScratch, 0, messageBuffer!, messageLength, result.Count);
                            messageLength += result.Count;

                            if (result.EndOfMessage)
                            {
                                messageQueue.Add(new PooledWebSocketMessage(messageBuffer!, messageLength, interactionContext), cancellationToken);
                                messageBuffer = null;
                                messageLength = 0;
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
                    catch (WebSocketException ex)
                    {
                        _logger?.LogWarning(ex, "WebSocket error while listening for chain sync messages.");

                        if (interactionContext.Socket.State != WebSocketState.Open) break;
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(ex, "Unexpected error while listening for chain sync messages.");
                    }
                }
            }
            finally
            {
                if (messageBuffer is not null)
                {
                    ArrayPool<byte>.Shared.Return(messageBuffer);
                }

                ArrayPool<byte>.Shared.Return(receiveScratch);
            }
        }

        private static void EnsureMessageCapacity(ref byte[]? messageBuffer, ref int messageLength, int additionalBytes)
        {
            var required = messageLength + additionalBytes;
            if (messageBuffer is not null && required <= messageBuffer.Length)
            {
                return;
            }

            var newCapacity = Math.Max(required, messageBuffer?.Length * 2 ?? ReceiveBufferSize);
            var newBuffer = ArrayPool<byte>.Shared.Rent(newCapacity);

            if (messageBuffer is not null)
            {
                if (messageLength > 0)
                {
                    Buffer.BlockCopy(messageBuffer, 0, newBuffer, 0, messageLength);
                }

                ArrayPool<byte>.Shared.Return(messageBuffer);
            }

            messageBuffer = newBuffer;
        }

        public async Task ProcessMessagesAsync(int maxBlocksPerSecond, CancellationToken cancellationToken)
        {
            var handlerChannel = Channel.CreateBounded<ChainSyncBlockWork>(new BoundedChannelOptions(HandlerQueueCapacity)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleReader = true,
                SingleWriter = true
            });

            var handlerTask = ProcessHandlerQueueAsync(handlerChannel.Reader, cancellationToken);

            try
            {
                await ProcessMessagesAsync(MessageQueue, handlerChannel.Writer, maxBlocksPerSecond, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                handlerChannel.Writer.TryComplete();
                await handlerTask.ConfigureAwait(false);
            }
        }

        private async Task ProcessMessagesAsync(
            BlockingCollection<PooledWebSocketMessage> messageQueue,
            ChannelWriter<ChainSyncBlockWork> handlerWriter,
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

                    await RequestNextBlockAsync(message.Context).ConfigureAwait(false);
                    requestStopwatch.Restart();

                    try
                    {
                        await _blockService.EnqueueBlockHandlersAsync(message.Memory, handlerWriter, cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(ex, "Error enqueueing block handler work.");
                    }
                    finally
                    {
                        message.Return();
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger?.LogDebug("Chain sync message processing cancelled.");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error processing chain sync messages.");
            }
        }

        private async Task ProcessHandlerQueueAsync(ChannelReader<ChainSyncBlockWork> reader, CancellationToken cancellationToken)
        {
            try
            {
                await foreach (var work in reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
                {
                    try
                    {
                        switch (work)
                        {
                            case ChainSyncRollBackwardWork rollback:
                                await _messageHandlers.RollBackwardHandler(rollback.Point, rollback.Tip).ConfigureAwait(false);
                                break;
                            case ChainSyncRollForwardWork forward:
                                await _messageHandlers.RollForwardHandler(forward.Block, forward.BlockType, forward.Tip).ConfigureAwait(false);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(ex, "Error executing chain sync handler.");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger?.LogDebug("Chain sync handler queue cancelled.");
            }
            catch (ChannelClosedException)
            {
                // Expected during shutdown.
            }
        }

        public async Task<List<StartingPointConfiguration>> ResumeAsync(List<Domain.InteractionContext> interactionContexts, int maxBlocksPerSecond, int inFlight = 100, CancellationToken cancellationToken = default)
        {
            await ShutdownSessionAsync().ConfigureAwait(false);

            CancellationTokenSource sessionCts;
            BlockingCollection<PooledWebSocketMessage> sessionQueue;
            Channel<ChainSyncBlockWork> handlerChannel;

            lock (_sessionLock)
            {
                sessionCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                sessionQueue = new BlockingCollection<PooledWebSocketMessage>(boundedCapacity: 1000);
                handlerChannel = Channel.CreateBounded<ChainSyncBlockWork>(new BoundedChannelOptions(HandlerQueueCapacity)
                {
                    FullMode = BoundedChannelFullMode.Wait,
                    SingleReader = true,
                    SingleWriter = true
                });
                _sessionCts = sessionCts;
                MessageQueue = sessionQueue;
                _sessionContexts = interactionContexts.ToList();
                _handlerQueueWriter = handlerChannel.Writer;
            }

            var sessionToken = sessionCts.Token;

            foreach (var context in interactionContexts)
            {
                await CreatePointFromCurrentTipAsync(context, context.StartingPoint).ConfigureAwait(false);
            }

            var tasks = new List<Task>
            {
                Task.Run(() => ProcessHandlerQueueAsync(handlerChannel.Reader, sessionToken), CancellationToken.None),
                Task.Run(() => ProcessMessagesAsync(sessionQueue, handlerChannel.Writer, maxBlocksPerSecond, sessionToken), CancellationToken.None),
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
            ChannelWriter<ChainSyncBlockWork>? handlerWriter;

            lock (_sessionLock)
            {
                cts = _sessionCts;
                tasks = _sessionTasks;
                contexts = _sessionContexts;
                handlerWriter = _handlerQueueWriter;
                _sessionCts = null;
                _sessionTasks = new List<Task>();
                _sessionContexts = new List<Domain.InteractionContext>();
                _handlerQueueWriter = null;
            }

            if (cts is null && tasks.Count == 0) return;

            try { cts?.Cancel(); }
            catch (ObjectDisposedException) { }

            handlerWriter?.TryComplete();

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

        private Task RequestNextBlockAsync(Domain.InteractionContext interactionContext)
        {
            try
            {
                return _blockService.GetNextBlockAsync(interactionContext);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error requesting next block.");
                return Task.CompletedTask;
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
            return intersection.Result.Tip.AsTip;
        }
    }
}
