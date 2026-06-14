using System.Collections.Concurrent;
using System.Threading.Channels;
using Corvus.Json;
using Generated;
using Microsoft.Extensions.Logging;
using Ogmios.Domain;

namespace Ogmios.Services.MemoryPoolMonitoring;

public class MemoryPoolMonitoringClientService(
    IMemoryPoolMonitoringService memoryPoolMonitoringService,
    ILogger<MemoryPoolMonitoringClientService>? logger = null) : IMemoryPoolMonitoringClientService
{
    private readonly IMemoryPoolMonitoringService _memoryPoolMonitoringService =
        memoryPoolMonitoringService ?? throw new ArgumentNullException(nameof(memoryPoolMonitoringService));
    private readonly ILogger<MemoryPoolMonitoringClientService>? _logger = logger;

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

        var transactionChannel = Channel.CreateBounded<Transaction>(new BoundedChannelOptions(options.HandlerQueueCapacity)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = true
        });

        var handlerTask = ProcessTransactionQueueAsync(transactionChannel.Reader, handlers, cancellationToken);

        try
        {
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
                        TrimDeduplicationSetIfNeeded(seenTransactionIds, options.MaxDeduplicationEntries);

                        var transactionId = (string)transaction.Id;
                        if (!seenTransactionIds.TryAdd(transactionId, 0))
                        {
                            continue;
                        }
                    }

                    await transactionChannel.Writer.WriteAsync(transaction, cancellationToken).ConfigureAwait(false);
                }
            }
        }
        finally
        {
            transactionChannel.Writer.TryComplete();
            await handlerTask.ConfigureAwait(false);
        }
    }

    public async Task ShutdownAsync(Domain.InteractionContext context, CancellationToken cancellationToken)
    {
        try
        {
            await _memoryPoolMonitoringService.ReleaseMempoolAsync(context, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger?.LogDebug(ex, "Best-effort mempool release failed during shutdown.");
        }

        await _memoryPoolMonitoringService.ShutdownAsync(context, cancellationToken).ConfigureAwait(false);
    }

    private static void TrimDeduplicationSetIfNeeded(ConcurrentDictionary<string, byte> seenTransactionIds, int maxEntries)
    {
        if (maxEntries <= 0 || seenTransactionIds.Count < maxEntries)
        {
            return;
        }

        seenTransactionIds.Clear();
    }

    private async Task ProcessTransactionQueueAsync(
        ChannelReader<Transaction> reader,
        IMemoryPoolMonitoringMessageHandlers handlers,
        CancellationToken cancellationToken)
    {
        try
        {
            await foreach (var transaction in reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
            {
                try
                {
                    await handlers.OnTransactionAsync(transaction, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Error executing mempool transaction handler.");
                }
            }
        }
        catch (OperationCanceledException)
        {
            _logger?.LogDebug("Mempool handler queue cancelled.");
        }
        catch (ChannelClosedException)
        {
            // Expected during shutdown.
        }
    }
}
