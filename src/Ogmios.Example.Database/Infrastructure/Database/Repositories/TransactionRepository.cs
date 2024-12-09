using Microsoft.EntityFrameworkCore;
using Ogmios.Example.Database.Entities;

namespace Ogmios.Example.Database.Infrastructure.Database.Repositories
{
    public class TransactionRepository(ApplicationDbContext context) : ITransactionRepository
    {
        private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task AddTransactionAsync(Transaction transaction)
        {
            var doesExist = await GetTransactionByIdAsync(transaction.Id);
            if (doesExist is not null) return;

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            Console.WriteLine("Transactions Saved:" + _context.Transactions.Count());
        }


        public async Task<Transaction?> GetTransactionByIdAsync(string transactionId)
        {
            return await _context.Transactions.FindAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            if (transaction != null)
            {
                _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(transaction));
            }
        }

        public async Task DeleteTransactionAsync(string id)
        {
            var transaction = await _context.Transactions.FindAsync(id) ?? throw new KeyNotFoundException($"Transaction with ID {id} not found.");
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
