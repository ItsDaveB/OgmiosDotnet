using System.Net.WebSockets;
using Moq;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.TransactionSubmission;

namespace Ogmios.Tests.TransactionSubmission;

public class TransactionSubmissionTests
{
    // TC001
    [Fact]
    public async Task SubmitTransaction_ThrowsOnFailedConnection()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocketService = new Mock<IWebSocketService>();
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new WebSocketException("Simulated connection failure"));

        var service = new TransactionSubmissionService(mockWebSocketService.Object);

        var signedCbor = Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.Parse("0");

        // Act & Assert
        await Assert.ThrowsAsync<WebSocketException>(() =>
            service.SubmitTransactionAsync(interactionContext, signedCbor, default, CancellationToken.None));
    }

    // TC002
    [Fact]
    public async Task SubmitTransaction_ThrowsOnInvalidResponse_parsingFailure()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocketService = new Mock<IWebSocketService>();
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
            It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("not valid json");

        var service = new TransactionSubmissionService(mockWebSocketService.Object);

        var signedCbor = Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.Parse("0");

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.SubmitTransactionAsync(interactionContext, signedCbor, default, CancellationToken.None));
    }

    // TC003
    [Fact]
    public async Task SubmitTransaction_ThrowsWhenRejected()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocketService = new Mock<IWebSocketService>();

        var errorJson = "{\"jsonrpc\":\"2.0\",\"method\":\"submitTransaction\",\"error\":{\"code\":4000,\"message\":\"Transaction was rejected\"}}";

        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
            It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(errorJson);

        var service = new TransactionSubmissionService(mockWebSocketService.Object);

        var signedCbor = Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.Parse("0");

        // Act & Assert
        await Assert.ThrowsAsync<SubmitTransactionFailedException>(() =>
            service.SubmitTransactionAsync(interactionContext, signedCbor, default, CancellationToken.None));
    }

    // TC004
    [Fact]
    public async Task SubmitTransaction_ReturnsOnSuccess()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocketService = new Mock<IWebSocketService>();

        var transactionSubmissionPayload = @"{
                ""jsonrpc"": ""2.0"",
                ""method"": ""submitTransaction"",
                ""result"": {
                    ""transaction"": {
                    ""id"": ""stringstringstringstringstringstringstringstringstringstringstri""
                    }
                },
                ""id"": ""1""
            }";
        string? capturedMessage = null;
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
            It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .Callback<string, IClientWebSocket, int, CancellationToken>((msg, sock, timeout, ct) => capturedMessage = msg)
            .ReturnsAsync(transactionSubmissionPayload);

        var service = new TransactionSubmissionService(mockWebSocketService.Object);

        var signedCbor = Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.Parse("0");

        // Act
        var response = await service.SubmitTransactionAsync(interactionContext, signedCbor, default, CancellationToken.None);

        // Assert
        Assert.True(response.IsSubmitTransactionSuccess);
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
