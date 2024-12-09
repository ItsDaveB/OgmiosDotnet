using Xunit;
using Ogmios.Example.Database.Services;
using Generated;
using Microsoft.EntityFrameworkCore;
using Ogmios.Example.Database.Infrastructure.Database;
using Ogmios.Example.Database.Infrastructure.Database.Repositories;
using AutoMapper;
using Ogmios.Example.Worker.Mappers;
using Ogmios.Services.ChainSynchronization;
using Moq;
using static Generated.BlockPraos;
using Corvus.Json;

namespace Ogmios.Example.Worker.Tests.ChainSynchronization;

public class ChainSynchronizationDatabaseTests : IDisposable
{
    private readonly ITransactionService _transactionService;
    private readonly ApplicationDbContext _context;
    private readonly ITransactionRepository _transactionRepository;

    public ChainSynchronizationDatabaseTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "ChainSynchronization").Options;

        _context = new ApplicationDbContext(options);
        _transactionRepository = new TransactionRepository(_context);
        _transactionService = new TransactionService(_transactionRepository, new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<TransactionMapping>())));
    }

    // TC001
    [Fact]
    public async Task RollForwardHandler_ShouldSaveTransactionsToDatabase_WhenProcessingValidBlock()
    {
        // Arrange
        var transaction = GetTestTransaction;
        var mockHandlers = new Mock<IChainSynchronizationMessageHandlers>();
        var block = Create(ancestor: AncestorEntity.DefaultInstance, era: EraEntity.DefaultInstance, height: BlockHeight.DefaultInstance, id: DigestBlake2b256.DefaultInstance, issuer: RequiredLeaderValueAndOperationalCertificateAndVerificationKeyAndVrfVerificationKey.DefaultInstance, protocol: RequiredVersion.DefaultInstance, size: NumberOfBytes.DefaultInstance, slot: Slot.DefaultInstance, TypeEntity.EnumValues.Praos, JsonAny.Null, transactions: [transaction]);
        var mockTransactionService = new Mock<ITransactionService>();

        mockHandlers
            .Setup(handler => handler.RollForwardHandler(It.IsAny<Block>(), It.IsAny<string>(), It.IsAny<Tip>()))
            .Callback<Block, string, Tip>(async (block, blockType, tip) =>
            {
                if (blockType == (string)BlockEbb.TypeEntity.EnumValues.Ebb) return;

                IEnumerable<Transaction>? transactions = blockType switch
                {
                    var type when type == (string)BlockBft.TypeEntity.EnumValues.Bft => block.AsBlockBft.Transactions,
                    var type when type == (string)TypeEntity.EnumValues.Praos => block.AsBlockPraos.Transactions,
                    _ => null
                };

                if (transactions == null) return;

                foreach (var transaction in transactions)
                {
                    await _transactionService.CreateTransactionAsync(transaction).ConfigureAwait(false);
                }
            })
            .Returns(Task.CompletedTask);

        // Act
        await mockHandlers.Object.RollForwardHandler(block, (string)TypeEntity.EnumValues.Praos, Tip.DefaultInstance);


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


    // TC002
    [Fact]
    public async Task GetTransactionAsync_WhenTransactionExists_ShouldRetrieveFromDatabase()
    {
        // Arrange
        var testTransaction = GetTestTransaction;

        // Act
        await _transactionService.CreateTransactionAsync(testTransaction);
        var transaction = await _transactionService.GetTransactionAsync((string)testTransaction.Id);

        // Assert
        Assert.NotNull(transaction);
        Assert.Equal((string)testTransaction.Id.AsString, (string)transaction.Value.Id.AsString);
        Assert.Equal(testTransaction.Inputs.Count(), transaction?.Inputs.Count());
        Assert.Equal(testTransaction.Outputs.Count(), transaction?.Outputs.Count());
        Assert.Equal(testTransaction.Fee.Ada.Lovelace.ToString(), transaction?.Fee.Ada.Lovelace.ToString());
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
