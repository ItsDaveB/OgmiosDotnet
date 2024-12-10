using Ogmios.Example.Database.Entities;

namespace Ogmios.Example.Database.Infrastructure.Database.Repositories;

public interface ITransactionRepository
{
    Task AddTransactionAsync(Transaction transaction);
    Task<Transaction?> GetTransactionByIdAsync(string id);
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    Task UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(string id);
}
