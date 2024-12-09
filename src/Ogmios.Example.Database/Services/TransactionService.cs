using AutoMapper;
using Corvus.Json;
using Ogmios.Example.Database.Infrastructure.Database.Repositories;
using Transaction = Ogmios.Example.Database.Entities.Transaction;

namespace Ogmios.Example.Database.Services;

public class TransactionService(ITransactionRepository transactionRepository, IMapper mapper) : ITransactionService
{
  private readonly ITransactionRepository _transactionRepository = transactionRepository;
  private readonly IMapper _mapper = mapper;

  public async Task CreateTransactionAsync(Generated.Transaction transaction)
  {
    if (transaction.IsNullOrUndefined())
    {
      throw new ArgumentNullException(transaction.ToString(), "Transaction is null or undefined.");
    }

    var transactionEntity = _mapper.Map<Transaction>(transaction);
    await _transactionRepository.AddTransactionAsync(transactionEntity);
  }

  public async Task<Generated.Transaction?> GetTransactionAsync(string transactionId)
  {
    var transactionEntity = await _transactionRepository.GetTransactionByIdAsync(transactionId);
    if (transactionEntity is null) return null;

    var transaction = Generated.Transaction.FromAny(JsonAny.CreateFromSerializedInstance(transactionEntity));
    return transaction;
  }
}