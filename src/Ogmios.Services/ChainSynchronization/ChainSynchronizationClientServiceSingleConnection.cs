// using System.Net.WebSockets;
// using System.Text;
// using System.Linq;
// using System.Threading.Channels;
// using Microsoft.Extensions.Configuration;
// using Ogmios.Domain.Schemas.Ogmios;
// using Ogmios.Services.InteractionContext;
// using static Ogmios.Domain.ChainSynchronization.BlockService;
// using System.Text.Json;

// namespace Ogmios.Domain.ChainSynchronization
// {
//     public class ChainSynchronizationClientService : IChainSynchronizationClientService
//     {
//         private readonly IChainSynchronizationMessageHandlers _messageHandlers;
//         private readonly IIntersectionService _intersectionService;
//         private readonly BlockService _blockService;
//         private readonly IConfiguration _configuration;
//         private InteractionContext _interactionContext; // Class-level field to store interaction context

//         // Concurrent queue to manage messages
//         private readonly Channel<string> _messageChannel;

//         // Dictionary to track request time for latency calculation
//         private readonly Dictionary<Guid, DateTime> _requestTimestamps = new();

//         public ChainSynchronizationClientService(
//             IChainSynchronizationMessageHandlers messageHandlers,
//             IIntersectionService intersectionService,
//             BlockService blockService,
//             IConfiguration configuration,
//             int maxInFlight = 100)
//         {
//             _messageHandlers = messageHandlers ?? throw new ArgumentNullException(nameof(messageHandlers));
//             _intersectionService = intersectionService ?? throw new ArgumentNullException(nameof(intersectionService));
//             _blockService = blockService ?? throw new ArgumentNullException(nameof(blockService));
//             _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

//             // Initialize the message channel with bounded capacity
//             _messageChannel = Channel.CreateBounded<string>(new BoundedChannelOptions(1000)
//             {
//                 SingleReader = true,
//                 SingleWriter = true
//             });
//         }

//         public async Task ResumeListeningAsync(InteractionContext interactionContext, CancellationToken cancellationToken)
//         {
//             _interactionContext = interactionContext; // Store the interaction context at the class level
//             var buffer = new byte[4096]; // 4 KB buffer size for WebSocket messages
//             var messageBuilder = new StringBuilder();

//             while (!cancellationToken.IsCancellationRequested && interactionContext.Socket.State == WebSocketState.Open)
//             {
//                 try
//                 {
//                     // Read a message segment from the WebSocket
//                     var result = await interactionContext.Socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

//                     // Check if the message type is text
//                     if (result.MessageType == WebSocketMessageType.Text)
//                     {
//                         // Append the received data to the message builder
//                         messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));

//                         // Check if this is the end of the message
//                         if (result.EndOfMessage)
//                         {
//                             // Get the complete message
//                             var message = messageBuilder.ToString();

//                             // Log the latency based on the request ID
//                             LogLatency(message);


//                             // Write the complete message to the message channel
//                             await _messageChannel.Writer.WriteAsync(message, cancellationToken);

//                             // Clear the message builder for the next message
//                             messageBuilder.Clear();
//                         }
//                     }
//                     else if (result.MessageType == WebSocketMessageType.Close)
//                     {
//                         // If the message type is close, close the WebSocket connection
//                         await ShutdownAsync(interactionContext).ConfigureAwait(false);
//                     }
//                 }
//                 catch (WebSocketException wsEx)
//                 {
//                     Console.WriteLine($"WebSocket error: {wsEx.Message}");
//                     // Handle WebSocket-specific errors, if necessary
//                 }
//                 catch (OperationCanceledException)
//                 {
//                     // This exception is expected when the cancellation token is triggered, no need to log
//                 }
//                 catch (Exception ex)
//                 {
//                     Console.WriteLine($"Unexpected error: {ex.Message}");
//                     // Handle other exceptions
//                 }
//             }

//             // Complete the writer after the listening loop has exited
//             if (!_messageChannel.Writer.TryComplete())
//             {
//                 Console.WriteLine("Failed to complete the writer");
//             }
//         }

//         private async Task ProcessMessagesAsync(CancellationToken cancellationToken)
//         {
//             try
//             {
//                 await foreach (var message in _messageChannel.Reader.ReadAllAsync(cancellationToken))
//                 {
//                     var requestId = ExtractRequestIdFromMessage(message);
//                     Console.WriteLine(requestId);
//                     await ProcessBlockMessageAsync(message);
//                     await RequestNextBlockAsync(_interactionContext);
//                 }
//             }
//             catch (OperationCanceledException)
//             {
//                 // Handle cancellation gracefully
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Error processing messages: {ex.Message}");
//             }
//         }

//         private async Task ProcessBlockMessageAsync(string message)
//         {
//             try
//             {
//                 await _blockService.HandleNextBlockAsync(message, _messageHandlers);
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Error processing block message: {ex.Message}");
//             }
//         }

//         public async Task<OgmiosPoint> ResumeAsync(InteractionContext interactionContext, CancellationToken cancellationToken = default, OgmiosPoint? point = null, int? inFlight = null)
//         {
//             _interactionContext = interactionContext; // Store the interaction context at the class level

//             var actualPoint = point ?? await CreatePointFromCurrentTipAsync(interactionContext).ConfigureAwait(false);

//             // Start processing messages in the background
//             _ = Task.Run(() => ProcessMessagesAsync(cancellationToken), cancellationToken);

//             // Start the WebSocket listener to receive block messages
//             _ = Task.Run(() => ResumeListeningAsync(interactionContext, cancellationToken));

//             // Fetch the initial 100 blocks
//             for (int i = 0; i < 100; i++)
//             {
//                 await RequestNextBlockAsync(interactionContext);
//             }

//             // Processing and requesting the next block will be handled in ProcessMessagesAsync method.

//             return actualPoint;
//         }

//         private async Task RequestNextBlockAsync(InteractionContext interactionContext)
//         {
//             try
//             {
//                 // Create a unique request ID
//                 var requestId = Guid.NewGuid();

//                 // Log the timestamp for latency measurement
//                 _requestTimestamps[requestId] = DateTime.UtcNow;

//                 // Request the next block with requestId in the message (assuming the service can process this ID)
//                 await _blockService.GetNextBlockAsync(interactionContext.Socket, requestId);
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Error requesting next block: {ex.Message}");
//             }
//         }

//         // Method to log latency for a received message
//         private void LogLatency(string message)
//         {
//             // Assuming the message contains the requestId
//             var requestId = ExtractRequestIdFromMessage(message);

//             if (requestId.HasValue && _requestTimestamps.TryGetValue(requestId.Value, out var requestTime))
//             {
//                 var latency = DateTime.UtcNow - requestTime;
//                 Console.WriteLine($"Latency for request {requestId.Value}: {latency.TotalMilliseconds} ms");

//                 // Remove the timestamp after logging to avoid memory leaks
//                 _requestTimestamps.Remove(requestId.Value);
//             }
//         }

//         private Guid? ExtractRequestIdFromMessage(string message)
//         {
//             try
//             {
//                 // Parse the JSON message
//                 var jsonDocument = JsonDocument.Parse(message);

//                 // Check if the root object contains an "id" property
//                 if (jsonDocument.RootElement.TryGetProperty("id", out JsonElement idElement))
//                 {
//                     // Get the id as a string and try to parse it as a Guid
//                     if (Guid.TryParse(idElement.GetString(), out Guid requestId))
//                     {
//                         return requestId;
//                     }
//                 }
//             }
//             catch (Exception ex) when (ex is JsonException || ex is ArgumentException)
//             {
//                 Console.WriteLine($"Failed to extract requestId: {ex.Message}");
//             }

//             return null; // Return null if the id is not found or cannot be parsed
//         }

//         public async Task ShutdownAsync(InteractionContext interactionContext)
//         {
//             if (interactionContext.Socket.State == WebSocketState.Open)
//             {
//                 await interactionContext.Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None).ConfigureAwait(false);
//             }
//         }

//         public async Task<OgmiosPoint> CreatePointFromCurrentTipAsync(InteractionContext context)
//         {
//             ArgumentNullException.ThrowIfNull(context);

//             var startingId = _configuration["StartingId"] ?? string.Empty;
//             var startingSlot = _configuration["StartingSlot"] ?? string.Empty;

//             var startingPoint = new OgmiosPoint
//             {
//                 Id = startingId,
//                 Slot = long.Parse(startingSlot)
//             };

//             var intersection = await _intersectionService.FindIntersectionAsync(context, new[] { startingPoint }).ConfigureAwait(false);
//             var tip = intersection?.Tip;

//             return new OgmiosPoint
//             {
//                 Id = tip?.Id ?? string.Empty,
//                 Slot = tip?.Slot ?? 0
//             };
//         }
//     }
// }
