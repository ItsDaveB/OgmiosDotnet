using System.Net.WebSockets;
using Corvus.Json;
using Generated;
using Moq;
using Ogmios.Domain;
using Ogmios.Services.MemoryPoolMonitoring;

namespace Ogmios.Tests.MemoryPoolMonitoring;

public class MemoryPoolMonitoringClientServiceTests
{
    [Fact]
    public async Task RunAsync_DrainsEveryTransactionBeforeNextAcquire()
    {
        var mempoolService = new Mock<IMemoryPoolMonitoringService>();
        var handlers = new Mock<IMemoryPoolMonitoringMessageHandlers>();
        var slot = Generated.Slot.ParseValue("12345");
        var transaction = CreateSampleTransaction("tx-one");

        var acquireCount = 0;
        var nextCall = 0;
        var cancellationTokenSource = new CancellationTokenSource();

        mempoolService
            .Setup(x => x.AcquireMempoolAsync(It.IsAny<InteractionContext>(), It.IsAny<CancellationToken>(), It.IsAny<MirrorOptions?>()))
            .ReturnsAsync(() =>
            {
                acquireCount++;
                if (acquireCount > 1)
                {
                    cancellationTokenSource.Cancel();
                }

                return Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot.Create(
                    acquired: Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot.AcquiredEntity.EnumValues.Mempool,
                    slot: slot);
            });

        mempoolService
            .Setup(x => x.NextTransactionAsync(It.IsAny<InteractionContext>(), It.IsAny<CancellationToken>(), It.IsAny<MirrorOptions?>()))
            .ReturnsAsync(() =>
            {
                nextCall++;
                return nextCall switch
                {
                    1 => WrapTransaction(transaction),
                    2 => Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity.Null,
                    _ => Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity.Null
                };
            });

        handlers
            .Setup(x => x.OnSnapshotAcquiredAsync(It.IsAny<Generated.Slot>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        handlers
            .Setup(x => x.OnTransactionAsync(It.IsAny<Transaction>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var service = new MemoryPoolMonitoringClientService(mempoolService.Object);

        await service.RunAsync(
            CreateInteractionContext(),
            handlers.Object,
            cancellationTokenSource.Token);

        handlers.Verify(x => x.OnTransactionAsync(It.IsAny<Transaction>(), It.IsAny<CancellationToken>()), Times.Once);
        mempoolService.Verify(x => x.AcquireMempoolAsync(It.IsAny<InteractionContext>(), It.IsAny<CancellationToken>(), It.IsAny<MirrorOptions?>()), Times.AtLeast(2));
        Assert.Equal(2, nextCall);
    }

    [Fact]
    public async Task RunAsync_DeduplicatesTransactionsWhenEnabled()
    {
        var mempoolService = new Mock<IMemoryPoolMonitoringService>();
        var handlers = new Mock<IMemoryPoolMonitoringMessageHandlers>();
        var slot = Generated.Slot.ParseValue("99");
        var transaction = CreateSampleTransaction("duplicate-tx");
        var cancellationTokenSource = new CancellationTokenSource();
        var acquireCount = 0;
        var nextCall = 0;

        mempoolService
            .Setup(x => x.AcquireMempoolAsync(It.IsAny<InteractionContext>(), It.IsAny<CancellationToken>(), It.IsAny<MirrorOptions?>()))
            .ReturnsAsync(Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot.Create(
                acquired: Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot.AcquiredEntity.EnumValues.Mempool,
                slot: slot))
            .Callback(() =>
            {
                acquireCount++;
                if (acquireCount > 1)
                {
                    cancellationTokenSource.Cancel();
                }
            });

        mempoolService
            .Setup(x => x.NextTransactionAsync(It.IsAny<InteractionContext>(), It.IsAny<CancellationToken>(), It.IsAny<MirrorOptions?>()))
            .ReturnsAsync(() =>
            {
                nextCall++;
                return nextCall switch
                {
                    1 or 2 => WrapTransaction(transaction),
                    _ => Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity.Null
                };
            });

        handlers
            .Setup(x => x.OnSnapshotAcquiredAsync(It.IsAny<Generated.Slot>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        handlers
            .Setup(x => x.OnTransactionAsync(It.IsAny<Transaction>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var service = new MemoryPoolMonitoringClientService(mempoolService.Object);

        await service.RunAsync(
            CreateInteractionContext(),
            handlers.Object,
            cancellationTokenSource.Token,
            new MemoryPoolMonitoringClientOptions { DeduplicateTransactions = true });

        handlers.Verify(x => x.OnTransactionAsync(It.IsAny<Transaction>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal(3, nextCall);
    }

    [Fact]
    public async Task DrainSnapshotExtension_InvokesCallbackUntilNull()
    {
        var mempoolService = new Mock<IMemoryPoolMonitoringService>();
        var transaction = CreateSampleTransaction("drain-tx");
        var nextCall = 0;
        var observed = 0;

        mempoolService
            .Setup(x => x.NextTransactionAsync(It.IsAny<InteractionContext>(), It.IsAny<CancellationToken>(), It.IsAny<MirrorOptions?>()))
            .ReturnsAsync(() =>
            {
                nextCall++;
                return nextCall == 1 ? WrapTransaction(transaction) : Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity.Null;
            });

        await mempoolService.Object.DrainSnapshotAsync(
            CreateInteractionContext(),
            (_, _) =>
            {
                observed++;
                return Task.CompletedTask;
            },
            CancellationToken.None);

        Assert.Equal(1, observed);
        Assert.Equal(2, nextCall);
    }

    private static Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity WrapTransaction(Transaction transaction)
    {
        return Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity.FromAny(
            JsonAny.CreateFromSerializedInstance(transaction));
    }

    private static Transaction CreateSampleTransaction(string idSeed)
    {
        return Transaction.Create(
            id: DigestBlake2b256.FromAny(idSeed),
            inputs: Transaction.InputsTransactionOutputRefArray.Create(items: []),
            outputs: Transaction.TransactionOutputArray.Create(items: []),
            signatories: Transaction.SignatoryArray.Create(items: []),
            spends: InputSource.EnumValues.Inputs,
            fee: ValueAdaOnly.Create(ValueAdaOnly.RequiredLovelace.Parse("1")));
    }

    private static InteractionContext CreateInteractionContext()
    {
        return new InteractionContext
        {
            StartingPoint = new StartingPointConfiguration { StartingPointIdOrOrigin = "origin" },
            Connection = new Connection
            {
                AddressHttp = new Uri("http://localhost:8080"),
                AddressWebSocket = new Uri("ws://localhost:8080"),
                Host = "localhost",
                Port = 8080
            },
            Socket = Mock.Of<IClientWebSocket>()
        };
    }
}
