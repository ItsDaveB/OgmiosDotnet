namespace Ogmios.Domain.Server;

public class ServerRuntimeStats
{
    public long GcCpuTime { get; set; }
    public long CpuTime { get; set; }
    public long MaxHeapSize { get; set; }
    public long CurrentHeapSize { get; set; }
}
