using System.Collections.Concurrent;
using Corvus.Json;
using Generated;
using Ogmios.Domain;

namespace Ogmios.Services.MemoryPoolMonitoring;

public class MemoryPoolMonitoringClientService(IMemoryPoolMonitoringService memoryPoolMonitoringService) : IMemoryPoolMonitoringClientService
{
    private readonly IMemoryPoolMonitoringService _memoryPoolMonitoringService =
        memoryPoolMonitoringService ?? throw new ArgumentNullException(nameof(memoryPoolMonitoringService));

    public async Task RunAsync(
        Domain.InteractionContext context,
        IMemoryPoolMonitoringMessageHandlers handlers,
        CancellationToken cancellationToken,
        MemoryPoolMonitoringClientOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(handlers);

        options ??= new MemoryPoolMonitoringClientOptions();
        var seenTransactionIds = options.DeduplicateTransactions
            ? new ConcurrentDictionary<string, byte>(StringComparer.Ordinal)
            : null;

        while (!cancellationToken.IsCancellationRequested)
        {
            var acquired = await _memoryPoolMonitoringService.AcquireMempoolAsync(context, cancellationToken).ConfigureAwait(false);
            await handlers.OnSnapshotAcquiredAsync(acquired.Slot, cancellationToken).ConfigureAwait(false);

            while (!cancellationToken.IsCancellationRequested)
            {
                var next = await _memoryPoolMonitoringService.NextTransactionAsync(context, cancellationToken).ConfigureAwait(false);
                if (next.AsTransaction.IsNullOrUndefined())
                {
                    break;
                }

                var transaction = next.AsTransaction;
                if (seenTransactionIds is not null)
                {
                    var transactionId = (string)transaction.Id;
                    if (!seenTransactionIds.TryAdd(transactionId, 0))
                    {
                        continue;
                    }
                }

                await handlers.OnTransactionAsync(transaction, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    public async Task ShutdownAsync(Domain.InteractionContext context, CancellationToken cancellationToken)
    {
        try
        {
            await _memoryPoolMonitoringService.ReleaseMempoolAsync(context, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception)
        {
            // Best-effort release before closing the socket.
        }

        await _memoryPoolMonitoringService.ShutdownAsync(context, cancellationToken).ConfigureAwait(false);
    }
}
