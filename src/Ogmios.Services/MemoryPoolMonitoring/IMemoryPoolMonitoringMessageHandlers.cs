using Generated;

namespace Ogmios.Services.MemoryPoolMonitoring;

/// <summary>
/// Callbacks invoked by <see cref="IMemoryPoolMonitoringClientService"/> for each mempool snapshot and transaction.
/// Keep implementations fast; offload heavy work to background workers.
/// </summary>
public interface IMemoryPoolMonitoringMessageHandlers
{
    Task OnSnapshotAcquiredAsync(Generated.Slot slot, CancellationToken cancellationToken);

    Task OnTransactionAsync(Transaction transaction, CancellationToken cancellationToken);
}
