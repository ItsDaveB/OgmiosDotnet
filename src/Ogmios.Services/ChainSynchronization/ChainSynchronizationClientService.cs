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
        public BlockingCollection<(byte[], Domain.InteractionContext)> MessageQueue { get; private set; } = new(boundedCapacity: 1000);

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
            BlockingCollection<(byte[], Domain.InteractionContext)> messageQueue,
            CancellationToken cancellationToken)
        {
            var buffer = new byte[65536]; // 64 KB buffer to reduce fragmented reads for large Cardano blocks
            using var messageStream = new MemoryStream();

            while (!cancellationToken.IsCancellationRequested && interactionContext.Socket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await interactionContext.Socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        messageStream.Write(buffer, 0, result.Count);

                        if (result.EndOfMessage)
                        {
                            var messageBytes = messageStream.ToArray();
                            messageQueue.Add((messageBytes, interactionContext), cancellationToken);
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

        public async Task ProcessMessagesAsync(int maxBlocksPerSecond, CancellationToken cancellationToken)
        {
            await ProcessMessagesAsync(MessageQueue, maxBlocksPerSecond, cancellationToken).ConfigureAwait(false);
        }

        private async Task ProcessMessagesAsync(
            BlockingCollection<(byte[], Domain.InteractionContext)> messageQueue,
            int maxBlocksPerSecond,
            CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in messageQueue.GetConsumingEnumerable(cancellationToken))
                {
                    var (messageBytes, context) = item;

                    await ProcessBlockMessageAsync(messageBytes);
                    await RequestNextBlockAsync(context);
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

        private async Task ProcessBlockMessageAsync(byte[] messageBytes)
        {
            try
            {
                await _blockService.HandleNextBlockAsync(new ReadOnlyMemory<byte>(messageBytes), _messageHandlers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing block message: {ex.Message}.");
            }
        }

        public async Task<List<StartingPointConfiguration>> ResumeAsync(List<Domain.InteractionContext> interactionContexts, int maxBlocksPerSecond, int inFlight = 100, CancellationToken cancellationToken = default)
        {
            // Terminate any previous session first so only one session pumps blocks.
            await ShutdownSessionAsync().ConfigureAwait(false);

            CancellationTokenSource sessionCts;
            BlockingCollection<(byte[], Domain.InteractionContext)> sessionQueue;
            lock (_sessionLock)
            {
                sessionCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                sessionQueue = new BlockingCollection<(byte[], Domain.InteractionContext)>(boundedCapacity: 1000);
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
                    await RequestNextBlockAsync(context);
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

            // Close sockets so a listener blocked inside ReceiveAsync unblocks.
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
                await _blockService.GetNextBlockAsync(interactionContext, new MirrorOptions { Id = requestId.ToString() });
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
