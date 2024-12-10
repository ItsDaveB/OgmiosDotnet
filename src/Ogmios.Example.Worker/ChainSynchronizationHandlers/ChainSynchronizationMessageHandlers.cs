using Generated;
using Ogmios.Example.Database.Services;
using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Example.Worker.ChainSynchronizationHandlers;

public class ChainSynchronizationMessageHandlers(ITransactionService transactionService) : IChainSynchronizationMessageHandlers
{
    private readonly ITransactionService _transactionService = transactionService;

    public async Task RollBackwardHandler(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip)
    {
        await Task.CompletedTask;
    }

    public async Task RollForwardHandler(Block block, string blockType, Tip tip)
    {
        if (blockType == (string)BlockEbb.TypeEntity.EnumValues.Ebb) return;

        IEnumerable<Transaction>? transactions = blockType switch
        {
            var type when type == (string)BlockBft.TypeEntity.EnumValues.Bft => block.AsBlockBft.Transactions,
            var type when type == (string)BlockPraos.TypeEntity.EnumValues.Praos => block.AsBlockPraos.Transactions,
            _ => null
        };

        if (transactions == null) return;

        foreach (var transaction in transactions)
        {
            await SaveTransactionAsync(transaction).ConfigureAwait(false);
        }
    }

    private async Task SaveTransactionAsync(Transaction transaction)
    {
        var doesExist = await GetTransactionAsync((string)transaction.Id) is not null;
        if (doesExist)
        {
            Console.WriteLine($"\u001b[32mTransaction Already Exists In Database.\u001b[0m");
            return;
        }

        Console.WriteLine($"\u001b[32mSaving Transaction.\u001b[0m");
        await _transactionService.CreateTransactionAsync(transaction);
        Console.WriteLine($"\u001b[32mTransaction Successfully Saved To Database.\u001b[0m");
    }

    private async Task<Transaction?> GetTransactionAsync(string transactionId)
    {
        Console.WriteLine($"\u001b[32mGetting Transaction From Database.\u001b[0m");
        var transactionEntity = await _transactionService.GetTransactionAsync(transactionId);
        Console.WriteLine($"\u001b[32mTransaction Successfully Retrieved From Database.\u001b[0m");

        return transactionEntity;
    }
}