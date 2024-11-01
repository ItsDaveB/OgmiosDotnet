using System.Net.WebSockets;
using System.Text.Json;
using Ogmios.Services.InteractionContext;
using Corvus.Json;
using Generated;

namespace Ogmios.Domain.ChainSynchronization;

public class BlockService
{
    private readonly BaseRequest baseRequest = new();
    public interface IChainSynchronizationMessageHandlers
    {
        Task RollBackwardHandler(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip);

        Task RollForwardHandler(Block block, string blockType, Tip tip);
    }

    public class BaseRequest
    {
        public string JsonRpc { get; set; } = "2.0";
    }

    public class MirrorOptions
    {
        /// <summary>
        /// A unique identifier sent with the request and expected to be mirrored by the server in the response.
        /// </summary>
        public string? Id { get; set; }
    }

    public async Task GetNextBlockAsync(InteractionContext context, MirrorOptions? options = null)
    {
        var request = new
        {
            jsonrpc = baseRequest.JsonRpc,
            method = "nextBlock",
            id = options?.Id ?? string.Empty
        };

        string jsonRequest = JsonSerializer.Serialize(request);
        Console.WriteLine($"NextBlock {context.ConnectionName}");

        await SendMessageAsync(context.Socket, jsonRequest);
    }


    public async Task HandleNextBlockAsync(string response, IChainSynchronizationMessageHandlers messageHandlers)
    {
        if (response is null)
        {
            return;
        }

        var result = ParsedValue<Generated.Ogmios.NextBlockResponse>.Parse(response);

        result.Instance.Result.TryGetProperty("direction", out var direction);
        result.Instance.Result.AsRollForward.Block.TryGetProperty("height", out var height);
        var blockheight = (int)height.AsNumber;
        Console.WriteLine($"Processed block height: {blockheight}");

        switch ((string)direction.AsString)
        {
            case "backward":
                Console.WriteLine($"rolling backwards.");
                var rollBackward = result.Instance.Result.AsRollBackward;
                await messageHandlers.RollBackwardHandler(rollBackward.Point, rollBackward.Tip);
                break;
            case "forward":
                Console.WriteLine($"rolling forwards.");
                var rollForward = result.Instance.Result.AsRollForward;
                rollForward.Block.TryGetProperty("type", out var blocktype);
                await messageHandlers.RollForwardHandler(rollForward.Block, (string)blocktype.AsString, rollForward.Tip);
                break;
            default:
                break;
        }

    }

    private Task SendMessageAsync(ClientWebSocket socket, string message)
    {
        var buffer = System.Text.Encoding.UTF8.GetBytes(message);
        var segment = new ArraySegment<byte>(buffer);

        return socket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
    }
}
