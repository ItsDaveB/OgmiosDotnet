using System.Net.WebSockets;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Corvus.Json;
using Ogmios.Domain;
using static Ogmios.Services.ChainSynchronization.BlockService;

namespace Ogmios.Services.ChainSynchronization;

public class IntersectionService : IIntersectionService
{
    public async Task<Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound> FindIntersectionAsync(Domain.InteractionContext context, IEnumerable<StartingPointConfiguration> points, MirrorOptions? options = null)
    {
        var pointItems = points?.Select(x => new
        {
            id = x.StartingId,
            slot = BigInteger.TryParse(x.StartingSlot.ToString(), out var parsedSlot) ? parsedSlot : BigInteger.Zero
        }).ToArray();

        var request = new
        {
            jsonrpc = "2.0",
            method = "findIntersection",
            @params = new { points = pointItems },
            id = options?.Id
        };

        string jsonRequest = JsonSerializer.Serialize(request, new JsonSerializerOptions
        {
            Converters = { new BigIntegerJsonConverter() }
        });

        await SendMessageAsync(context.Socket, jsonRequest);
        var jsonResponse = await ReceiveMessageAsync(context.Socket);

        var result = ParsedValue<Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound>.Parse(jsonResponse);
        return result.Instance;
    }

    public class TipIsOriginException : Exception
    {
        public TipIsOriginException()
            : base("The tip is set to 'origin'.")
        {
        }
    }

    private async Task<string> ReceiveMessageAsync(ClientWebSocket socket)
    {
        var buffer = new byte[1024];
        var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        if (result.MessageType == WebSocketMessageType.Close)
        {
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
        }

        var jsonResponse = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
        Console.ForegroundColor = ConsoleColor.Green;
        return jsonResponse;
    }

    private async Task SendMessageAsync(ClientWebSocket socket, string message)
    {
        var buffer = System.Text.Encoding.UTF8.GetBytes(message);
        var segment = new ArraySegment<byte>(buffer);
        await socket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
    }

    public class BigIntegerJsonConverter : JsonConverter<BigInteger>
    {
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            _ = BigInteger.TryParse(reader.GetString(), out BigInteger result);
            return result;
        }

        public override void Write(Utf8JsonWriter writer, BigInteger bigIntegerValue, JsonSerializerOptions options)
        {
            writer.WriteRawValue(bigIntegerValue.ToString(), skipInputValidation: true);
        }
    }
}
