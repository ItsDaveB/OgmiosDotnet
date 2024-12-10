namespace Ogmios.Example.Database.Services;

public interface ITransactionService
{
    Task CreateTransactionAsync(Generated.Transaction transaction);
    Task<Generated.Transaction?> GetTransactionAsync(string transactionId);
}