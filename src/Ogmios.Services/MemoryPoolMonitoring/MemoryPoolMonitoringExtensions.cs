using Corvus.Json;
using Generated;
using Ogmios.Domain;

namespace Ogmios.Services.MemoryPoolMonitoring;

/// <summary>
/// Performance-oriented helpers for consumers calling <see cref="IMemoryPoolMonitoringService"/> directly.
/// </summary>
public static class MemoryPoolMonitoringExtensions
{
    /// <summary>
    /// Drains every transaction from the currently acquired mempool snapshot.
    /// Call after <see cref="IMemoryPoolMonitoringService.AcquireMempoolAsync"/>.
    /// </summary>
    public static async Task DrainSnapshotAsync(
        this IMemoryPoolMonitoringService service,
        Domain.InteractionContext context,
        Func<Transaction, CancellationToken, Task> onTransaction,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(onTransaction);

        while (!cancellationToken.IsCancellationRequested)
        {
            var next = await service.NextTransactionAsync(context, cancellationToken).ConfigureAwait(false);
            if (next.AsTransaction.IsNullOrUndefined())
            {
                break;
            }

            await onTransaction(next.AsTransaction, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// High-throughput monitoring loop: acquire snapshot, drain all transactions, wait for next change, repeat.
    /// Uses only acquire + nextTransaction RPCs on the hot path.
    /// </summary>
    public static async Task MonitorAsync(
        this IMemoryPoolMonitoringService service,
        Domain.InteractionContext context,
        Func<Transaction, CancellationToken, Task> onTransaction,
        CancellationToken cancellationToken,
        Func<Generated.Slot, CancellationToken, Task>? onSnapshotAcquired = null)
    {
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(onTransaction);

        while (!cancellationToken.IsCancellationRequested)
        {
            var acquired = await service.AcquireMempoolAsync(context, cancellationToken).ConfigureAwait(false);

            if (onSnapshotAcquired is not null)
            {
                await onSnapshotAcquired(acquired.Slot, cancellationToken).ConfigureAwait(false);
            }

            await service.DrainSnapshotAsync(context, onTransaction, cancellationToken).ConfigureAwait(false);
        }
    }
}
