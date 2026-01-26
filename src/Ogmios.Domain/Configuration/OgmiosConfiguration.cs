namespace Ogmios.Domain
{
    public class OgmiosConfiguration
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public int MaxBlocksPerSecond { get; set; } = 100;
        public bool Tls { get; set; } = true;
        public string SslValidation { get; set; } = "Auto";
    }
}