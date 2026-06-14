using Generated;
using Ogmios.Domain;
using Ogmios.Example.Database.Services;
using Ogmios.Services.MemoryPoolMonitoring;

namespace Ogmios.Example.Worker.Examples;

/// <summary>
/// Demonstrates high-throughput mempool monitoring via <see cref="IMemoryPoolMonitoringClientService"/>.
/// Uses acquire → drain-all → repeat with optional transaction deduplication.
/// </summary>
public class MemPoolMonitoringExample(
    IMemoryPoolMonitoringClientService memoryPoolMonitoringClientService,
    ITransactionService transactionService) : IExample
{
    public string Name => "MemPool Monitoring";

    public async Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken)
    {
        Console.WriteLine("\u001b[33m--- MemPool Monitoring Demonstration ---\u001b[0m");
        Console.WriteLine("\u001b[36m[MemPool] Starting high-throughput mempool monitoring...\u001b[0m");

        var handlers = new MempoolMonitoringHandlers(transactionService);

        try
        {
            await memoryPoolMonitoringClientService.RunAsync(
                context,
                handlers,
                cancellationToken,
                new MemoryPoolMonitoringClientOptions { DeduplicateTransactions = true });
        }
        finally
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await memoryPoolMonitoringClientService.ShutdownAsync(context, CancellationToken.None);
            }
        }

        Console.WriteLine("\u001b[33m--- MemPool Monitoring Demonstration Complete ---\u001b[0m");
    }

    private sealed class MempoolMonitoringHandlers(ITransactionService transactionService) : IMemoryPoolMonitoringMessageHandlers
    {
        public Task OnSnapshotAcquiredAsync(Generated.Slot slot, CancellationToken cancellationToken)
        {
            Console.WriteLine($"\u001b[32m[MemPool] Snapshot acquired at slot {slot}\u001b[0m");
            return Task.CompletedTask;
        }

        public async Task OnTransactionAsync(Generated.Transaction transaction, CancellationToken cancellationToken)
        {
            var transactionId = (string)transaction.Id;
            var existing = await transactionService.GetTransactionAsync(transactionId).ConfigureAwait(false);
            if (existing is not null)
            {
                return;
            }

            await transactionService.CreateTransactionAsync(transaction).ConfigureAwait(false);
            Console.WriteLine($"\u001b[32m[MemPool] Saved transaction {transactionId[..16]}...\u001b[0m");
        }
    }
}
