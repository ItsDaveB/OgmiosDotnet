using System.Net.WebSockets;
using Moq;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.TransactionEvaluation;

namespace Ogmios.Tests.TransactionEvaluation;

public class TransactionEvaluationTests
{
    // TC005
    [Fact]
    public async Task EvaluateTransaction_ThrowsOnFailedConnection()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocketService = new Mock<IWebSocketService>();
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new WebSocketException("Simulated connection failure"));

        var service = new TransactionEvaluationService(mockWebSocketService.Object);

        var signedCbor = Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.Parse("0");

        // Act & Assert
        await Assert.ThrowsAsync<WebSocketException>(() =>
            service.EvaluateTransactionAsync(interactionContext, signedCbor, default, CancellationToken.None));
    }

    // TC006
    [Fact]
    public async Task EvaluateTransaction_ThrowsOnInvalidResponse_parsingFailure()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocketService = new Mock<IWebSocketService>();
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
            It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("not valid json");

        var service = new TransactionEvaluationService(mockWebSocketService.Object);

        var signedCbor = Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.Parse("0");

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.EvaluateTransactionAsync(interactionContext, signedCbor, default, CancellationToken.None));
    }

    // TC007
    [Fact]
    public async Task EvaluateTransaction_ThrowsWhenRejected()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocketService = new Mock<IWebSocketService>();

        var errorJson = "{\"jsonrpc\":\"2.0\",\"method\":\"evaluateTransaction\",\"error\":{\"code\":4000,\"message\":\"Transaction evaluation failed\"}}";

        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
            It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(errorJson);

        var service = new TransactionEvaluationService(mockWebSocketService.Object);

        var signedCbor = Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.Parse("0");

        // Act & Assert
        await Assert.ThrowsAsync<EvaluateTransactionFailedException>(() =>
            service.EvaluateTransactionAsync(interactionContext, signedCbor, default, CancellationToken.None));
    }

    // TC008
    [Fact]
    public async Task EvaluateTransaction_ReturnsOnSuccess()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocketService = new Mock<IWebSocketService>();

        var transactionEvaluationPayload = @"{
                ""jsonrpc"": ""2.0"",
                ""method"": ""evaluateTransaction"",
                ""result"": [
                    {
                        ""validator"": {
                            ""purpose"": ""spend"",
                            ""index"": 0
                        },
                        ""budget"": {
                            ""memory"": 1000000,
                            ""cpu"": 500000000
                        }
                    }
                ]
            }";
        string? capturedMessage = null;
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
            It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .Callback<string, IClientWebSocket, int, CancellationToken>((msg, sock, timeout, ct) => capturedMessage = msg)
            .ReturnsAsync(transactionEvaluationPayload);

        var service = new TransactionEvaluationService(mockWebSocketService.Object);

        var signedCbor = Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.Parse("0");

        // Act
        var response = await service.EvaluateTransactionAsync(interactionContext, signedCbor, default, CancellationToken.None);

        // Assert
        Assert.True(response.IsEvaluateTransactionSuccess);
        Assert.False(string.IsNullOrEmpty(capturedMessage));
    }

    private static InteractionContext CreateMockInteractionContext(string host = "localhost", int port = 8080)
    {
        var mockSocket = new Mock<IClientWebSocket>();
        mockSocket.Setup(x => x.State).Returns(WebSocketState.Open);

        var connection = new Connection
        {
            AddressHttp = new Uri("https://test-url.com:443"),
            Host = host,
            Port = port,
            AddressWebSocket = new Uri($"ws://{host}:{port}")
        };

        return new InteractionContext
        {
            StartingPoint = new StartingPointConfiguration() { StartingPointIdOrOrigin = "origin" },
            Connection = connection,
            Socket = mockSocket.Object
        };
    }
}
