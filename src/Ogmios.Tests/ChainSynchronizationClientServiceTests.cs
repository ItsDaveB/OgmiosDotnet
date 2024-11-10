using System.Net.WebSockets;
using System.Text;
using Generated;
using Moq;
using Ogmios.Domain;
using Ogmios.Domain.Exceptions;
using Ogmios.Services.ChainSynchronization;
using static Generated.Ogmios.PointOrOrigin;
using static Ogmios.Services.ChainSynchronization.BlockService;

namespace Ogmios.Tests
{
    public class ChainSynchronizationClientServiceTests
    {
        private readonly Mock<IChainSynchronizationMessageHandlers> _mockMessageHandlers;
        private readonly Mock<IIntersectionService> _mockIntersectionService;
        private readonly Mock<IBlockService> _mockBlockService;
        private readonly ChainSynchronizationClientService _service;

        public ChainSynchronizationClientServiceTests()
        {
            _mockMessageHandlers = new Mock<IChainSynchronizationMessageHandlers>();
            _mockIntersectionService = new Mock<IIntersectionService>();
            _mockBlockService = new Mock<IBlockService>();

            _service = new ChainSynchronizationClientService(_mockMessageHandlers.Object, _mockIntersectionService.Object, _mockBlockService.Object);
        }

        [Fact]
        public async Task ResumeListeningAsync_ClosesSocketOnCloseMessage()
        {
            // Arrange
            var interactionContext = CreateMockInteractionContext();
            var cancellationTokenSource = new CancellationTokenSource();

            var mockSocket = Mock.Get(interactionContext.Socket);
            mockSocket.Setup(x => x.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new WebSocketReceiveResult(0, WebSocketMessageType.Close, true));

            // Act
            await _service.ResumeListeningAsync(interactionContext, cancellationTokenSource.Token);

            // Assert
            mockSocket.Verify(x => x.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ResumeListeningAsync_QueuesWebSocketResponseMessages()
        {
            // Arrange
            const string message = "WebSocket Response Test Message";
            var buffer = Encoding.UTF8.GetBytes(message);
            var interactionContext = CreateMockInteractionContext();
            var cancellationTokenSource = new CancellationTokenSource();

            var mockSocket = Mock.Get(interactionContext.Socket);
            int callCount = 0;

            // Setup the mocked WebSocket behavior
            mockSocket.Setup(x => x.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ArraySegment<byte> segment, CancellationToken token) =>
                {
                    if (callCount++ == 0 && segment.Array != null)
                    {
                        Array.Copy(buffer, segment.Array, buffer.Length);
                        return new WebSocketReceiveResult(buffer.Length, WebSocketMessageType.Text, true);
                    }
                    return new WebSocketReceiveResult(0, WebSocketMessageType.Close, true);
                });

            // Act
            await _service.ResumeListeningAsync(interactionContext, cancellationTokenSource.Token);

            // Assert
            Assert.Single(_service.MessageQueue);
            var (queuedMessage, context) = _service.MessageQueue.First();
            Assert.Equal(message, queuedMessage);
            Assert.Equal(interactionContext, context);

            mockSocket.Verify(
                x => x.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", It.IsAny<CancellationToken>()),
                Times.Once
            );
        }

        [Fact]
        public async Task ProcessMessagesAsync_ProcessesQueuedMessagesFromWebSocketResponse()
        {
            // Arrange
            const string message = "Test block message";
            var buffer = Encoding.UTF8.GetBytes(message);
            var interactionContext = CreateMockInteractionContext();
            var cancellationTokenSource = new CancellationTokenSource();

            var mockSocket = Mock.Get(interactionContext.Socket);
            int callCount = 0;

            // Setup the mocked WebSocket behavior to queue a message
            mockSocket.Setup(x => x.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ArraySegment<byte> segment, CancellationToken token) =>
                {
                    if (callCount++ == 0 && segment.Array != null)
                    {
                        Array.Copy(buffer, segment.Array, buffer.Length);
                        return new WebSocketReceiveResult(buffer.Length, WebSocketMessageType.Text, true);
                    }
                    return new WebSocketReceiveResult(0, WebSocketMessageType.Close, true);
                });

            // Act
            // Start the WebSocket listening, which should queue the message
            await _service.ResumeListeningAsync(interactionContext, cancellationTokenSource.Token);

            // Use a short delay to ensure the message is queued before processing
            cancellationTokenSource.CancelAfter(2000);
            await _service.ProcessMessagesAsync(cancellationTokenSource.Token);

            // Assert
            _mockBlockService.Verify(
                x => x.HandleNextBlockAsync(message, _mockMessageHandlers.Object),
                Times.Once,
                "Expected HandleNextBlockAsync to be called once with the correct message and handlers."
            );
        }

        [Fact]
        public async Task ResumeListeningAsync_ProcessesMessagesInCorrectOrder()
        {
            // Arrange
            var message1 = "Message 1";
            var message2 = "Message 2";
            var message3 = "Message 3";

            var buffer1 = Encoding.UTF8.GetBytes(message1);
            var buffer2 = Encoding.UTF8.GetBytes(message2);
            var buffer3 = Encoding.UTF8.GetBytes(message3);

            var interactionContext = CreateMockInteractionContext();
            var cancellationTokenSource = new CancellationTokenSource();
            var messageLog = new List<string>();

            var mockSocket = Mock.Get(interactionContext.Socket);
            int callCount = 0;

            // Setup the mocked WebSocket behavior to send messages in order
            mockSocket.Setup(x => x.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ArraySegment<byte> segment, CancellationToken token) =>
                {
                    if (segment.Array == null) throw new ArgumentNullException(nameof(segment.Array));
                    var buffers = new[] { buffer1, buffer2, buffer3 };

                    if (callCount < buffers.Length)
                    {
                        Array.Copy(buffers[callCount], segment.Array, buffers[callCount].Length);
                        return new WebSocketReceiveResult(buffers[callCount++].Length, WebSocketMessageType.Text, true);
                    }

                    return new WebSocketReceiveResult(0, WebSocketMessageType.Close, true);
                });

            // Setup the message handlers to log the order of message processing
            _mockBlockService.Setup(x => x.HandleNextBlockAsync(It.IsAny<string>(), It.IsAny<IChainSynchronizationMessageHandlers>()))
                .Callback<string, IChainSynchronizationMessageHandlers>((message, _) =>
                {
                    messageLog.Add(message);
                })
                .Returns(Task.CompletedTask);

            // Act
            await _service.ResumeListeningAsync(interactionContext, cancellationTokenSource.Token);

            // Use a short delay to ensure the message is queued before processing
            cancellationTokenSource.CancelAfter(2000);
            await _service.ProcessMessagesAsync(cancellationTokenSource.Token);

            // Assert
            Assert.Equal(3, messageLog.Count);
            Assert.Equal(message1, messageLog[0]);
            Assert.Equal(message2, messageLog[1]);
            Assert.Equal(message3, messageLog[2]);
        }

        [Fact]
        public async Task ResumeListeningAsync_SelectsTipAsIntersection_WhenNoPointProvided()
        {
            // Arrange
            var interactionContext = CreateMockInteractionContext();
            var point = Point.Create(id: interactionContext.StartingPoint.StartingPointIdOrOrigin, slot: Slot.FromAny(interactionContext.StartingPoint.StartingPointSlot));
            var tip = Tip.Create(height: BlockHeight.FromAny(string.Empty), id: interactionContext.StartingPoint.StartingPointIdOrOrigin, Slot.FromAny(interactionContext.StartingPoint.StartingPointSlot));

            var intersectionFound = Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound.Create(
                jsonrpc: "2.0",
                method: "findIntersection",
                result: Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound.RequiredIntersectionAndTip.Create(intersection: point, tip: tip));

            // Setup the mock to return the expected Intersection object
            _mockIntersectionService
                .Setup(x => x.FindIntersectionAsync(
                    It.Is<InteractionContext>(ctx => ctx == interactionContext),
                    It.IsAny<StartingPointConfiguration>(),
                    It.IsAny<MirrorOptions>()))
                .ReturnsAsync(intersectionFound);

            // Act
            var intersection = await _service.ResumeAsync([interactionContext], inFlight: 10, CancellationToken.None);

            // Assert
            Assert.Equal(interactionContext.StartingPoint.StartingPointIdOrOrigin, intersection.First().StartingPointIdOrOrigin);
            Assert.Equal(interactionContext.StartingPoint.StartingPointSlot, intersection.First().StartingPointSlot);
        }

        [Fact]
        public async Task ResumeListeningAsync_ThrowsIntersectionNotFoundException_WhenNoIntersectionFound()
        {
            // Arrange
            var interactionContext = CreateMockInteractionContext();
            _mockIntersectionService.Setup(x => x.FindIntersectionAsync
                    (It.Is<InteractionContext>(ctx => ctx == interactionContext),
                    It.IsAny<StartingPointConfiguration>(),
                    It.IsAny<MirrorOptions>()))
                .ThrowsAsync(new IntersectionNotFoundException("No intersection found"));

            // Act & Assert
            await Assert.ThrowsAsync<IntersectionNotFoundException>(async () =>
            {
                await _service.ResumeAsync([interactionContext], inFlight: 10, CancellationToken.None);
            });
        }

        [Fact]
        public async Task ResumeListeningAsync_IntersectsAtGenesis_WhenOriginProvidedAsPoint()
        {
            // Arrange
            var interactionContext = CreateMockInteractionContext();
            interactionContext.StartingPoint.StartingPointIdOrOrigin = "origin";

            // Act
            var intersection = await _service.ResumeAsync([interactionContext], inFlight: 10, CancellationToken.None);

            // Assert
            Assert.Equal("origin", intersection.First().StartingPointIdOrOrigin);
        }

        private static InteractionContext CreateMockInteractionContext(WebSocketState socketState = WebSocketState.Open)
        {
            var mockSocket = new Mock<IClientWebSocket>();
            mockSocket.Setup(x => x.State).Returns(socketState);

            var startingPoint = new StartingPointConfiguration
            {
                StartingPointIdOrOrigin = "0000000000000000000000000000000000000000000000000000000000000000",
                StartingPointSlot = 0
            };

            var connection = new Connection
            {
                Host = "localhost",
                Port = 8080,
                Tls = false,
                MaxPayload = 1024,
                AddressHttp = new Uri("http://localhost:8080"),
                AddressWebSocket = new Uri("ws://localhost:8080")
            };

            return new InteractionContext
            {
                ConnectionName = "TestConnection",
                StartingPoint = startingPoint,
                Connection = connection,
                Socket = mockSocket.Object
            };
        }

        // [Fact]
        // public async Task ProcessMessagesAsync_PerformsBetterWithPipelining()
        // {
        //     // Arrange
        //     var messageCount = 1000;
        //     var interactionContext = CreateMockInteractionContext();
        //     var messages = Enumerable.Range(0, messageCount).Select(i => $"Message {i}").ToArray();
        //     var buffers = messages.Select(Encoding.UTF8.GetBytes).ToArray();

        //     var mockSocket = Mock.Get(interactionContext.Socket);
        //     int callCount = 0;
        //     mockSocket.Setup(x => x.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
        //         .ReturnsAsync((ArraySegment<byte> segment, CancellationToken token) =>
        //         {
        //             if (callCount < buffers.Length)
        //             {
        //                 Array.Copy(buffers[callCount], segment.Array, buffers[callCount].Length);
        //                 return new WebSocketReceiveResult(buffers[callCount++].Length, WebSocketMessageType.Text, true);
        //             }
        //             return new WebSocketReceiveResult(0, WebSocketMessageType.Close, true);
        //         });

        //     // Act
        //     var stopwatch = Stopwatch.StartNew();
        //     await _service.ResumeListeningAsync(interactionContext, CancellationToken.None);
        //     await _service.ProcessMessagesAsync(CancellationToken.None);
        //     stopwatch.Stop();
        //     var nonPipelinedTime = stopwatch.ElapsedMilliseconds;

        //     // Measure with pipelining
        //     _service.EnablePipelining(); // Hypothetical method to enable pipelining
        //     stopwatch.Restart();
        //     await _service.ProcessMessagesAsync(CancellationToken.None);
        //     stopwatch.Stop();
        //     var pipelinedTime = stopwatch.ElapsedMilliseconds;

        //     // Assert
        //     Assert.True(pipelinedTime < nonPipelinedTime, "Pipelined processing should be faster than non-pipelined.");
        // }

        //     [Fact]
        //     public async Task ClientMethods_ThrowException_AfterShutdown()
        //     {
        //         // Arrange
        //         var interactionContext = CreateMockInteractionContext();
        //         await _service.ResumeListeningAsync(interactionContext, CancellationToken.None);
        //         await _service.ShutdownAsync(interactionContext);

        //         // Act & Assert
        //         await Assert.ThrowsAsync<InvalidOperationException>(() => _service.ResumeListeningAsync(interactionContext, CancellationToken.None));
        //     }
    }
}
