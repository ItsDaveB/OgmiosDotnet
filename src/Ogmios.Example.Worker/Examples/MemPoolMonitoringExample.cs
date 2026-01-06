using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Example.Database.Services;
using Ogmios.Services.InteractionContext;
using Ogmios.Services.MemoryPoolMonitoring;

namespace Ogmios.Example.Worker.Examples;

/// <summary>
/// Demonstrates the Memory Pool (Mempool) Monitoring capabilities of Ogmios.
/// Shows how to acquire a mempool snapshot, query transactions, and monitor for new transactions.
/// </summary>
public class MemPoolMonitoringExample(
    IMemoryPoolMonitoringService memoryPoolMonitoringService,
    ITransactionService transactionService) : IExample
{
    public string Name => "MemPool Monitoring";

    public async Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken)
    {
        Console.WriteLine("\u001b[33m--- MemPool Monitoring Demonstration ---\u001b[0m");

        Console.WriteLine($"\u001b[36m[MemPool] Acquiring mempool snapshot...\u001b[0m");

        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("\u001b[33m[MemPool] Waiting for changes in the mempool snapshot...\u001b[0m");

            var mempoolAcquired = await memoryPoolMonitoringService.AcquireMempoolAsync(context, cancellationToken);
            var mempoolSizeAndCapacity = await memoryPoolMonitoringService.SizeOfMempoolAsync(context, cancellationToken);

            Console.WriteLine($"\u001b[32m[MemPool] Maximum capacity (bytes): {mempoolSizeAndCapacity.MaxCapacity.Bytes}\u001b[0m");
            Console.WriteLine($"\u001b[32m[MemPool] Current size (bytes): {mempoolSizeAndCapacity.CurrentSize.Bytes}\u001b[0m");

            var nextTransaction = await memoryPoolMonitoringService.NextTransactionAsync(context, cancellationToken);
            if (nextTransaction.IsNullOrUndefined())
            {
                Console.WriteLine($"\u001b[33m[MemPool] No transactions in mempool snapshot.\u001b[0m");
                continue;
            }

            var nextTransactionEntity = nextTransaction.AsTransaction;
            Console.WriteLine($"\u001b[32m[MemPool] Transaction Id: {nextTransactionEntity.Id}\u001b[0m");
            Console.WriteLine($"\u001b[32m[MemPool] Transaction Fee: {nextTransactionEntity.Fee}\u001b[0m");

            if (nextTransactionEntity.Metadata.IsNotNullOrUndefined())
            {
                var formattedLabels = string.Join("\n", nextTransactionEntity.Metadata.Labels.Select(label =>
                    $"\u001b[32m  Key: {label.Key}\n  Value: {label.Value}\u001b[0m"));
                Console.WriteLine($"\u001b[32m[MemPool] Transaction Metadata:\n{formattedLabels}\u001b[0m");
            }

            Console.WriteLine($"\u001b[32m[MemPool] Transaction Inputs: {nextTransactionEntity.Inputs.Count()}\u001b[0m");
            Console.WriteLine($"\u001b[32m[MemPool] Transaction Outputs: {nextTransactionEntity.Outputs.Count()}\u001b[0m");

            // Check if a specific transaction exists in the mempool
            var sampleTxId = "eddc4a21f5da916a3f8b0a8c1dc6cbeec790d058ce8ecb9390f326489768bbf1";
            var hasTransaction = await memoryPoolMonitoringService.HasTransactionAsync(context, sampleTxId, cancellationToken);
            Console.WriteLine($"\u001b[32m[MemPool] Transaction {sampleTxId[..16]}... exists in snapshot?: {hasTransaction.Result}\u001b[0m");

            // Save transaction to database
            await SaveTransactionAsync(nextTransaction.AsTransaction);

            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"\u001b[36m[MemPool] Releasing mempool snapshot...\u001b[0m");
                await memoryPoolMonitoringService.ReleaseMempoolAsync(context, cancellationToken);
                await memoryPoolMonitoringService.ShutdownAsync(context, cancellationToken);
                Console.WriteLine($"\u001b[32m[MemPool] Mempool released and shutdown complete.\u001b[0m");
            }
        }

        Console.WriteLine("\u001b[33m--- MemPool Monitoring Demonstration Complete ---\u001b[0m");
    }

    private async Task SaveTransactionAsync(Generated.Transaction transaction)
    {
        var transactionId = (string)transaction.Id;
        var existingTransaction = await transactionService.GetTransactionAsync(transactionId);

        if (existingTransaction is not null)
        {
            Console.WriteLine($"\u001b[33m[MemPool] Transaction already exists in database.\u001b[0m");
            return;
        }

        Console.WriteLine($"\u001b[36m[MemPool] Saving transaction to database...\u001b[0m");
        await transactionService.CreateTransactionAsync(transaction);
        Console.WriteLine($"\u001b[32m[MemPool] Transaction successfully saved to database.\u001b[0m");
    }
}
