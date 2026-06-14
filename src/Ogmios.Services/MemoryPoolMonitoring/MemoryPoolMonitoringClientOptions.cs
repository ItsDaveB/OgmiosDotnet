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
}
