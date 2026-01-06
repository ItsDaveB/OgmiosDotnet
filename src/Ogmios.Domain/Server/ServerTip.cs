using System.Text.Json.Serialization;

namespace Ogmios.Domain.Server;

public class ServerTip
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("slot")]
    public ulong Slot { get; set; }

    [JsonPropertyName("height")]
    public ulong Height { get; set; }
}