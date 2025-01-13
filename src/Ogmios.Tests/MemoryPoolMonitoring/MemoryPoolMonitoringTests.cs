using System.Net.WebSockets;
using Corvus.Json;
using Moq;
using Ogmios.Domain;
using Ogmios.Domain.Exceptions;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.MemoryPoolMonitoring;

namespace Ogmios.Tests.MemoryPoolMonitoring;

public class MempoolMonitoringClientTests
{
    // TC001
    [Fact]
    public async Task ShutdownAsync_ClosesWebSocket()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();

        var mockWebSocket = new Mock<IClientWebSocket>();
        mockWebSocket.Setup(x => x.State).Returns(WebSocketState.Open);
        mockWebSocket.Setup(x => x.CloseAsync(
                WebSocketCloseStatus.NormalClosure,
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        interactionContext.Socket = mockWebSocket.Object;

        var service = new MemoryPoolMonitoringService(new WebSocketService());

        // Act
        await service.ShutdownAsync(interactionContext, CancellationToken.None);

        // Assert
        mockWebSocket.Verify(x => x.CloseAsync(WebSocketCloseStatus.NormalClosure, It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    // TC002
    [Fact]
    public async Task CreateClient_ThrowsOnFailedConnection()
    {
        // Arrange
        var interactionContextInvalidHost = CreateMockInteractionContext(host: "non-existent");
        var interactionContextInvalidPort = CreateMockInteractionContext(port: 1111);

        var mockWebSocketService = new Mock<IWebSocketService>();
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(It.IsAny<string>(), It.IsAny<IClientWebSocket>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ThrowsAsync(new WebSocketException("Simulated connection failure"));

        var service = new MemoryPoolMonitoringService(mockWebSocketService.Object);

        // Act & Assert
        await Assert.ThrowsAsync<WebSocketException>(() =>
            service.AcquireMempoolAsync(interactionContextInvalidHost, CancellationToken.None));
        await Assert.ThrowsAsync<WebSocketException>(() =>
            service.AcquireMempoolAsync(interactionContextInvalidPort, CancellationToken.None));
    }

    // TC003
    [Fact]
    public async Task AcquireMempool_SuccessfullyAcquiresFirstSnapshot()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();
        var slot = "140317981";

        var mockWebSocketService = new Mock<IWebSocketService>();

        var validResponseJson = Generated.Ogmios.AcquireMempoolResponse.Create(jsonrpc: Generated.Ogmios.AcquireMempoolResponse.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.AcquireMempoolResponse.MethodEntity.EnumValues.AcquireMempool, result: Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot.Create(acquired: Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot.AcquiredEntity.EnumValues.Mempool, slot: Generated.Slot.ParseValue(slot)));
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
                It.IsAny<string>(),
                It.IsAny<IClientWebSocket>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(validResponseJson.AsJsonElement.ToString());

        var service = new MemoryPoolMonitoringService(mockWebSocketService.Object);

        // Act
        var snapshot = await service.AcquireMempoolAsync(interactionContext, CancellationToken.None);

        // Assert
        Assert.Equal(Convert.ToInt64(slot), snapshot.Slot.AsInt64());
    }

    // TC004
    [Fact]
    public async Task HasTransaction_ReturnsFalseForMissingTransaction()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();
        var mockWebSocketService = new Mock<IWebSocketService>();
        var service = new MemoryPoolMonitoringService(mockWebSocketService.Object);

        var hasTransactionResponseJson = Generated.Ogmios.HasTransactionResponseEntity.HasTransactionResponse.Create(jsonrpc: Generated.Ogmios.HasTransactionResponseEntity.HasTransactionResponse.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.HasTransactionResponseEntity.HasTransactionResponse.MethodEntity.EnumValues.HasTransaction, result: false);
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
                     It.IsAny<string>(),
                     It.IsAny<IClientWebSocket>(),
                     It.IsAny<int>(),
                     It.IsAny<CancellationToken>()))
                 .ReturnsAsync(hasTransactionResponseJson.AsJsonElement.ToString());

        // Act
        var exists = await service.HasTransactionAsync(interactionContext, "4f539156bfbefc070a3b61cad3d1cedab3050e2b2a62f0ffe16a43eb0edc1ce8", CancellationToken.None);

        // Assert
        Assert.False(exists.Result);
    }

    // TC005
    [Fact]
    public async Task HasTransaction_ThrowsWhenNoSnapshotAcquired()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();
        var mockWebSocketService = new Mock<IWebSocketService>();
        var service = new MemoryPoolMonitoringService(mockWebSocketService.Object);


        var hasTransactionResponseJson = Generated.Ogmios.MustAcquireMempoolFirst.Create(error: Generated.Ogmios.MustAcquireMempoolFirst.MustAcquireAMempoolSnapshotPriorToPerformingAnyQuery.Create(code: 4000, message: "You must acquire a mempool snapshot prior to accessing it."), jsonrpc: Generated.Ogmios.MustAcquireMempoolFirst.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.MustAcquireMempoolFirst.MethodEntity.EnumValues.HasTransaction);
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
                     It.IsAny<string>(),
                     It.IsAny<IClientWebSocket>(),
                     It.IsAny<int>(),
                     It.IsAny<CancellationToken>()))
                 .ReturnsAsync(hasTransactionResponseJson.AsJsonElement.ToString());

        // Act & Assert
        await Assert.ThrowsAsync<MustAcquireMempoolFirstException>(() => service.HasTransactionAsync(interactionContext, "4f539156bfbefc070a3b61cad3d1cedab3050e2b2a62f0ffe16a43eb0edc1ce8", CancellationToken.None));
    }

    // TC006
    [Fact]
    public async Task NextTransaction_ReturnsNullWhenNoTransactions()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();
        var mockWebSocketService = new Mock<IWebSocketService>();

        var nextTransactionResponseJson = Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.Create(
            jsonrpc: Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.JsonrpcEntity.EnumValues.Value20,
            method: Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.MethodEntity.EnumValues.NextTransaction,
            result: Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.Null
        );
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
                It.IsAny<string>(),
                It.IsAny<IClientWebSocket>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(nextTransactionResponseJson.AsJsonElement.ToString());

        var service = new MemoryPoolMonitoringService(mockWebSocketService.Object);

        // Act
        var transaction = await service.NextTransactionAsync(interactionContext, CancellationToken.None);
        var isNullOrUndefined = transaction.AsTransaction.IsNullOrUndefined();

        // Assert
        Assert.True(isNullOrUndefined);
    }

    // TC007
    [Fact]
    public async Task NextTransaction_ThrowsWhenNoSnapshotAcquired()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();
        var mockWebSocketService = new Mock<IWebSocketService>();

        var nextTransactionErrorResponseJson = Generated.Ogmios.MustAcquireMempoolFirst.Create(
            error: Generated.Ogmios.MustAcquireMempoolFirst.MustAcquireAMempoolSnapshotPriorToPerformingAnyQuery.Create(
                code: 4000,
                message: "You must acquire a mempool snapshot prior to accessing it."
            ),
            jsonrpc: Generated.Ogmios.MustAcquireMempoolFirst.JsonrpcEntity.EnumValues.Value20,
            method: Generated.Ogmios.MustAcquireMempoolFirst.MethodEntity.EnumValues.NextTransaction
        );
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
                It.IsAny<string>(),
                It.IsAny<IClientWebSocket>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(nextTransactionErrorResponseJson.AsJsonElement.ToString());

        var service = new MemoryPoolMonitoringService(mockWebSocketService.Object);

        // Act & Assert
        await Assert.ThrowsAsync<MustAcquireMempoolFirstException>(() =>
            service.NextTransactionAsync(interactionContext, CancellationToken.None));
    }

    // TC008
    [Fact]
    public async Task SizeOfMempool_ReturnsStats()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();
        var mockWebSocketService = new Mock<IWebSocketService>();

        var mempoolSizeResponseJson = Generated.Ogmios.SizeOfMempoolResponseEntity.SizeOfMempoolResponse.Create(
            jsonrpc: Generated.Ogmios.SizeOfMempoolResponseEntity.SizeOfMempoolResponse.JsonrpcEntity.EnumValues.Value20,
            method: Generated.Ogmios.SizeOfMempoolResponseEntity.SizeOfMempoolResponse.MethodEntity.EnumValues.SizeOfMempool,
            result: Generated.Ogmios.MempoolSizeAndCapacity.Create(currentSize: Generated.NumberOfBytes.Create(0), maxCapacity: Generated.NumberOfBytes.Create(1000000), transactions: Generated.Ogmios.MempoolSizeAndCapacity.RequiredCountEntity.Create(Generated.UInt32.ParseValue("5")))
        );

        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
                It.IsAny<string>(),
                It.IsAny<IClientWebSocket>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(mempoolSizeResponseJson.AsJsonElement.ToString());

        var service = new MemoryPoolMonitoringService(mockWebSocketService.Object);

        // Act
        var stats = await service.SizeOfMempoolAsync(interactionContext, CancellationToken.None);

        // Assert
        Assert.Equal(1000000, stats.MaxCapacity.Bytes);
        Assert.Equal(0, stats.CurrentSize.Bytes);
        Assert.Equal(1, stats.Transactions.Count);
    }

    // TC009
    [Fact]
    public async Task SizeOfMempool_ThrowsWhenNoSnapshotAcquired()
    {
        // Arrange
        var interactionContext = CreateMockInteractionContext();
        var mockWebSocketService = new Mock<IWebSocketService>();

        var mempoolSizeErrorResponseJson = Generated.Ogmios.MustAcquireMempoolFirst.Create(
            error: Generated.Ogmios.MustAcquireMempoolFirst.MustAcquireAMempoolSnapshotPriorToPerformingAnyQuery.Create(
                code: 4000,
                message: "You must acquire a mempool snapshot prior to accessing it."
            ),
            jsonrpc: Generated.Ogmios.MustAcquireMempoolFirst.JsonrpcEntity.EnumValues.Value20,
            method: Generated.Ogmios.MustAcquireMempoolFirst.MethodEntity.EnumValues.SizeOfMempool
        );
        mockWebSocketService.Setup(x => x.SendAndWaitForResponseAsync(
                It.IsAny<string>(),
                It.IsAny<IClientWebSocket>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(mempoolSizeErrorResponseJson.AsJsonElement.ToString());

        var service = new MemoryPoolMonitoringService(mockWebSocketService.Object);

        // Act & Assert
        await Assert.ThrowsAsync<MustAcquireMempoolFirstException>(() =>
            service.SizeOfMempoolAsync(interactionContext, CancellationToken.None));
    }

    private static InteractionContext CreateMockInteractionContext(string host = "localhost", int port = 8080)
    {
        var mockSocket = new Mock<IClientWebSocket>();
        mockSocket.Setup(x => x.State).Returns(WebSocketState.Open);

        var connection = new Connection
        {
            AddressHttp = new Uri("https://example-url.com:443"),
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
