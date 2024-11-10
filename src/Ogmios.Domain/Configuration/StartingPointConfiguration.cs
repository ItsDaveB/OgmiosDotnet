namespace Ogmios.Domain
{
    public class StartingPointConfiguration
    {
        public required string StartingPointIdOrOrigin { get; set; } = "origin";
        public long StartingPointSlot { get; set; }
    }
}