using System.Net.WebSockets;
using System.Text;
using Ogmios.Services.InteractionContext;
using static Ogmios.Domain.ChainSynchronization.BlockService;
using System.Collections.Concurrent;
using Ogmios.Domain.Configuration;

namespace Ogmios.Domain.ChainSynchronization
{
    public class ChainSynchronizationClientService(IChainSynchronizationMessageHandlers messageHandlers, IIntersectionService intersectionService, BlockService blockService) : IChainSynchronizationClientService
    {
        private readonly IChainSynchronizationMessageHandlers _messageHandlers = messageHandlers ?? throw new ArgumentNullException(nameof(messageHandlers));
        private readonly IIntersectionService _intersectionService = intersectionService ?? throw new ArgumentNullException(nameof(intersectionService));
        private readonly BlockService _blockService = blockService ?? throw new ArgumentNullException(nameof(blockService));
        private readonly Dictionary<Guid, DateTime> _requestTimestamps = [];
        private readonly BlockingCollection<(string, InteractionContext)> _messageQueue = [];

        public async Task ResumeListeningAsync(InteractionContext interactionContext, CancellationToken cancellationToken)
        {
            var buffer = new byte[1024]; // 8 KB buffer size for WebSocket messages
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
                            _messageQueue.Add((message, interactionContext), cancellationToken);
                            messageBuilder.Clear();
                        }
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await ShutdownAsync(interactionContext).ConfigureAwait(false);
                    }
                }
                catch (WebSocketException wsEx)
                {
                    Console.WriteLine($"WebSocket error: {wsEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }
        private async Task ProcessMessagesAsync(CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in _messageQueue.GetConsumingEnumerable(cancellationToken))
                {
                    var (message, context) = item;

                    await ProcessBlockMessageAsync(message);
                    await RequestNextBlockAsync(context);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Processing cancelled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing messages: {ex.Message}");
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
                Console.WriteLine($"Error processing block message: {ex.Message}");
            }
        }

        public async Task<List<StartingPointConfiguration>> ResumeAsync(List<InteractionContext> interactionContexts, int inFlight = 100, CancellationToken cancellationToken = default)
        {
            foreach (var context in interactionContexts)
            {
                await CreatePointFromCurrentTipAsync(context, [context.StartingPoint]).ConfigureAwait(false);
            }

            _ = Task.Run(() => ProcessMessagesAsync(cancellationToken), cancellationToken);

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

        private async Task RequestNextBlockAsync(InteractionContext interactionContext)
        {
            try
            {
                var requestId = Guid.NewGuid();
                _requestTimestamps[requestId] = DateTime.UtcNow;

                await _blockService.GetNextBlockAsync(interactionContext, new MirrorOptions { Id = requestId.ToString() });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error requesting next block: {ex.Message}");
            }
        }

        public async Task ShutdownAsync(InteractionContext interactionContext)
        {
            if (interactionContext.Socket.State == WebSocketState.Open)
            {
                await interactionContext.Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None).ConfigureAwait(false);
            }
        }

        public async Task<Generated.Ogmios.TipOrOrigin> CreatePointFromCurrentTipAsync(InteractionContext context, IEnumerable<StartingPointConfiguration> startingPoints)
        {
            ArgumentNullException.ThrowIfNull(context);

            var intersection = await _intersectionService.FindIntersectionAsync(context, startingPoints).ConfigureAwait(false);
            var tip = intersection.Result.Tip.AsTip;

            return tip;
        }
    }
}
