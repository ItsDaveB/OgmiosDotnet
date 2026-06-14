using System.Threading.Channels;
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
    /// Uses only acquire + nextTransaction RPCs on the hot path and offloads callbacks to a bounded queue.
    /// </summary>
    public static async Task MonitorAsync(
        this IMemoryPoolMonitoringService service,
        Domain.InteractionContext context,
        Func<Transaction, CancellationToken, Task> onTransaction,
        CancellationToken cancellationToken,
        Func<Generated.Slot, CancellationToken, Task>? onSnapshotAcquired = null,
        int handlerQueueCapacity = 2000)
    {
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(onTransaction);

        var transactionChannel = Channel.CreateBounded<Transaction>(new BoundedChannelOptions(handlerQueueCapacity)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = true
        });

        var handlerTask = ProcessTransactionCallbacksAsync(transactionChannel.Reader, onTransaction, cancellationToken);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var acquired = await service.AcquireMempoolAsync(context, cancellationToken).ConfigureAwait(false);

                if (onSnapshotAcquired is not null)
                {
                    await onSnapshotAcquired(acquired.Slot, cancellationToken).ConfigureAwait(false);
                }

                while (!cancellationToken.IsCancellationRequested)
                {
                    var next = await service.NextTransactionAsync(context, cancellationToken).ConfigureAwait(false);
                    if (next.AsTransaction.IsNullOrUndefined())
                    {
                        break;
                    }

                    await transactionChannel.Writer.WriteAsync(next.AsTransaction, cancellationToken).ConfigureAwait(false);
                }
            }
        }
        finally
        {
            transactionChannel.Writer.TryComplete();
            await handlerTask.ConfigureAwait(false);
        }
    }

    private static async Task ProcessTransactionCallbacksAsync(
        ChannelReader<Transaction> reader,
        Func<Transaction, CancellationToken, Task> onTransaction,
        CancellationToken cancellationToken)
    {
        await foreach (var transaction in reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
        {
            await onTransaction(transaction, cancellationToken).ConfigureAwait(false);
        }
    }
}
