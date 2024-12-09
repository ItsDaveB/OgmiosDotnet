using Xunit;
using Ogmios.Example.Database.Services;
using Generated;
using Microsoft.EntityFrameworkCore;
using Ogmios.Example.Database.Infrastructure.Database;
using Ogmios.Example.Database.Infrastructure.Database.Repositories;
using AutoMapper;
using Ogmios.Example.Worker.Mappers;
using Moq;
using Ogmios.Services.MemoryPoolMonitoring;
using Ogmios.Domain;

namespace Ogmios.Example.Worker.Tests.MemoryPoolMonitoring;

public class MemoryPoolMonitoringDatabaseTests : IDisposable
{
    private readonly ITransactionService _transactionService;
    private readonly ApplicationDbContext _context;
    private readonly ITransactionRepository _transactionRepository;
    private readonly Mock<IMemoryPoolMonitoringService> _memoryPoolMonitoringService;

    public MemoryPoolMonitoringDatabaseTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "MemoryPoolMonitoring").Options;

        _context = new ApplicationDbContext(options);
        _transactionRepository = new TransactionRepository(_context);
        _transactionService = new TransactionService(_transactionRepository, new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<TransactionMapping>())));
        _memoryPoolMonitoringService = new Mock<IMemoryPoolMonitoringService>();
    }

    // TC003
    [Fact]
    public async Task SaveTransaction_WhenValidTransactionIsProvided_ShouldPersistToDatabase()
    {
        // Arrange
        var transaction = GetTestTransaction;

        _memoryPoolMonitoringService
            .Setup(service => service.NextTransactionAsync(It.IsAny<InteractionContext>(), It.IsAny<CancellationToken>(), It.IsAny<MirrorOptions>()))
            .ReturnsAsync(transaction);

        // Act
        var result = await _memoryPoolMonitoringService.Object.NextTransactionAsync(It.IsAny<InteractionContext>(), CancellationToken.None);
        await _transactionService.CreateTransactionAsync(result.AsTransaction);

        // Assert
        var savedTransaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transaction.Id);
        Assert.NotNull(savedTransaction);
        Assert.Equal(transaction.Id, savedTransaction.Id);
        Assert.NotNull(savedTransaction.Outputs);
        Assert.Equal(transaction.Outputs.First().Address.ToString(), savedTransaction?.Outputs.Value.FirstOrDefault().Address.ToString());
        Assert.Equal(transaction.Outputs.First().Value.Ada.Lovelace.ToString(), savedTransaction?.Outputs.Value.FirstOrDefault().Value.Ada.Lovelace.ToString());
        Assert.NotNull(savedTransaction?.Fee);
        Assert.Equal(transaction.Fee.Ada.Lovelace.ToString(), savedTransaction?.Fee.Value.Ada.Lovelace.ToString());
    }

    // TC004
    [Fact]
    public async Task GetTransactionAsync_WhenTransactionExistsInDatabase_ShouldReturnCorrectTransaction()
    {
        // Arrange
        var mocktransaction = GetTestTransaction;

        _memoryPoolMonitoringService
            .Setup(service => service.NextTransactionAsync(It.IsAny<InteractionContext>(), It.IsAny<CancellationToken>(), It.IsAny<MirrorOptions>()))
            .ReturnsAsync(mocktransaction);

        // Act
        var result = await _memoryPoolMonitoringService.Object.NextTransactionAsync(It.IsAny<InteractionContext>(), CancellationToken.None);
        await _transactionService.CreateTransactionAsync(result.AsTransaction);

        var transaction = await _transactionService.GetTransactionAsync((string)mocktransaction.Id);

        // Assert
        Assert.Equal((string)transaction.Value.Id.AsString, (string)mocktransaction.Id.AsString);
        Assert.Equal(transaction.Value.Inputs.Count(), mocktransaction.Inputs.Count());
        Assert.Equal(transaction.Value.Outputs.Count(), mocktransaction.Outputs.Count());
        Assert.Equal(transaction.Value.Fee.Ada.Lovelace.ToString(), mocktransaction.Fee.Ada.Lovelace.ToString());
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    private static Transaction GetTestTransaction => Transaction.Create(id: DigestBlake2b256.FromAny("22332"),
                                                                        inputs: Transaction.InputsTransactionOutputRefArray.Create(items: [TransactionOutputReference.Create(index: 0, transaction: TransactionOutputReference.RequiredId.Create(TransactionId.DefaultInstance)),
                                                                                                                                           TransactionOutputReference.Create(index: 0, transaction: TransactionOutputReference.RequiredId.Create(TransactionId.DefaultInstance))]),
                                                                        outputs: Transaction.TransactionOutputArray.Create(items: [TransactionOutput.Create(address: "address", value: Value.Parse("2000000"))]),
                                                                        signatories: Transaction.SignatoryArray.Create(items: [Signatory.Create(key: VerificationKey.DefaultInstance, signature: Signature.DefaultInstance)]),
                                                                        spends: InputSource.EnumValues.Inputs, fee: ValueAdaOnly.Create(ValueAdaOnly.RequiredLovelace.Parse("1")));


}
