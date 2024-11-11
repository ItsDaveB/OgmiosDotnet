namespace Ogmios.Domain.Server;

public class ServerHealth
{
    public required string CurrentEra { get; set; }
    public required ServerTip LastKnownTip { get; set; }
    public required string LastTipUpdate { get; set; }
    public required Metrics Metrics { get; set; }
    public required string StartTime { get; set; }
    public required string Network { get; set; }
    public double NetworkSynchronization { get; set; }
    public required string Version { get; set; }
}