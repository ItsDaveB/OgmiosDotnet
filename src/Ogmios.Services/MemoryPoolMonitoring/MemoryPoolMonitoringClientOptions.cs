namespace Ogmios.Services.MemoryPoolMonitoring;

/// <summary>
/// Performance and behaviour options for <see cref="IMemoryPoolMonitoringClientService.RunAsync"/>.
/// </summary>
public sealed class MemoryPoolMonitoringClientOptions
{
    /// <summary>
    /// When enabled, transactions already delivered to <see cref="IMemoryPoolMonitoringMessageHandlers.OnTransactionAsync"/>
    /// during this session are not dispatched again. Disable when every mempool appearance must be observed.
    /// </summary>
    public bool DeduplicateTransactions { get; set; } = true;

    /// <summary>
    /// Maximum queued transactions awaiting handler execution. Provides backpressure when handlers are slow.
    /// </summary>
    public int HandlerQueueCapacity { get; set; } = 2000;

    /// <summary>
    /// Maximum number of transaction ids tracked for deduplication before the set is reset.
    /// </summary>
    public int MaxDeduplicationEntries { get; set; } = 100_000;
}
