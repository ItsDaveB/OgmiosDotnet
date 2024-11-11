namespace Ogmios.Domain.Server;

public class Metrics
{
    public required ServerRuntimeStats RuntimeStats { get; set; }
    public required ServerSessionDurations SessionDurations { get; set; }
    public int TotalConnections { get; set; }
    public int TotalMessages { get; set; }
    public int TotalUnrouted { get; set; }
    public int ActiveConnections { get; set; }
}