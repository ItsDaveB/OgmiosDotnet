using Ogmios.Domain;

namespace Ogmios.Services.MemoryPoolMonitoring;

/// <summary>
/// High-throughput mempool monitoring session: acquire snapshot, drain all transactions, repeat.
/// Use a dedicated <see cref="InteractionContext"/> (separate WebSocket from chain sync).
/// </summary>
public interface IMemoryPoolMonitoringClientService
{
    /// <summary>
    /// Runs until <paramref name="cancellationToken"/> is cancelled.
    /// Drains every transaction in each snapshot before waiting for the next mempool change.
    /// </summary>
    Task RunAsync(
        Domain.InteractionContext context,
        IMemoryPoolMonitoringMessageHandlers handlers,
        CancellationToken cancellationToken,
        MemoryPoolMonitoringClientOptions? options = null);

    /// <summary>
    /// Releases the active mempool snapshot and closes the WebSocket.
    /// </summary>
    Task ShutdownAsync(Domain.InteractionContext context, CancellationToken cancellationToken);
}
