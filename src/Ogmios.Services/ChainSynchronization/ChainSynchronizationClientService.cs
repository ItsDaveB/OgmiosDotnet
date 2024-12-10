using System.Net.WebSockets;
using System.Text;
using System.Collections.Concurrent;
using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization
{
    public class ChainSynchronizationClientService(IChainSynchronizationMessageHandlers messageHandlers, IIntersectionService intersectionService, IBlockService blockService) : IChainSynchronizationClientService
    {
        public readonly BlockingCollection<(string, Domain.InteractionContext)> MessageQueue = new(boundedCapacity: 1000);
        private readonly IChainSynchronizationMessageHandlers _messageHandlers = messageHandlers ?? throw new ArgumentNullException(nameof(messageHandlers));
        private readonly IIntersectionService _intersectionService = intersectionService ?? throw new ArgumentNullException(nameof(intersectionService));
        private readonly IBlockService _blockService = blockService ?? throw new ArgumentNullException(nameof(blockService));
        private readonly SemaphoreSlim _rateLimiter = new(1, 1);

        public async Task ResumeListeningAsync(Domain.InteractionContext interactionContext, CancellationToken cancellationToken)
        {
            var buffer = new byte[8192]; // 8 KB buffer size for WebSocket messages
            var messageBuilder = new StringBuilder();

            while (!cancellationToken.IsCancellationRequested && interactionContext.Socket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await interactionContext.Socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));

                        if (result.EndOfMessage)
                        {
                            var message = messageBuilder.ToString();
                            MessageQueue.Add((message, interactionContext), cancellationToken);
                            messageBuilder.Clear();
                        }
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await ShutdownAsync(interactionContext).ConfigureAwait(false);
                        break;
                    }
                }
                catch (WebSocketException webSocketException)
                {
                    Console.WriteLine($"WebSocket error: {webSocketException.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        public async Task ProcessMessagesAsync(int maxBlocksPerSecond, CancellationToken cancellationToken)
        {
            var timeWindow = TimeSpan.FromSeconds(1.0 / maxBlocksPerSecond);

            try
            {
                foreach (var item in MessageQueue.GetConsumingEnumerable(cancellationToken))
                {
                    var (message, context) = item;
                    await _rateLimiter.WaitAsync(cancellationToken);

                    try
                    {

                        await ProcessBlockMessageAsync(message);
                        await RequestNextBlockAsync(context);
                    }
                    finally
                    {
                        await Task.Delay(timeWindow, cancellationToken);
                        _rateLimiter.Release();
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

        private async Task ProcessBlockMessageAsync(string message)
        {
            try
            {
                await _blockService.HandleNextBlockAsync(message, _messageHandlers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing block message: {ex.Message}.");
            }
        }

        public async Task<List<StartingPointConfiguration>> ResumeAsync(List<Domain.InteractionContext> interactionContexts, int maxBlocksPerSecond, int inFlight = 100, CancellationToken cancellationToken = default)
        {
            foreach (var context in interactionContexts)
            {
                await CreatePointFromCurrentTipAsync(context, context.StartingPoint).ConfigureAwait(false);
            }

            _ = Task.Run(() => ProcessMessagesAsync(maxBlocksPerSecond, cancellationToken), cancellationToken);

            foreach (var context in interactionContexts)
            {
                _ = Task.Run(() => ResumeListeningAsync(context, cancellationToken), cancellationToken);
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
