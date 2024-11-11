using Corvus.Json;

namespace Ogmios.Services.ChainSynchronization;

public class BlockService(IWebSocketService webSocketService) : IBlockService
{
    public class MirrorOptions
    {
        /// <summary>
        /// A unique identifier sent with the request and expected to be mirrored by the server in the response.
        /// </summary>
        public string? Id { get; set; }
    }

    public Task GetNextBlockAsync(Domain.InteractionContext context, MirrorOptions? options = null)
    {
        var nextBlockRequest = Generated.Ogmios.NextBlock.Create(jsonrpc: Generated.Ogmios.NextBlock.JsonrpcEntity.EnumValues.V20, method: Generated.Ogmios.NextBlock.MethodEntity.EnumValues.NextBlock, id: options?.Id ?? string.Empty);
        return webSocketService.SendMessageAsync(nextBlockRequest.AsJsonElement.ToString(), context.Socket);
    }

    public async Task HandleNextBlockAsync(string response, IChainSynchronizationMessageHandlers messageHandlers)
    {
        if (string.IsNullOrEmpty(response))
        {
            return;
        }

        var result = ParsedValue<Generated.Ogmios.NextBlockResponse>.Parse(response);
        result.Instance.Result.TryGetProperty("direction", out var direction);

        switch ((string)direction.AsString)
        {
            case "backward":
                var rollBackward = result.Instance.Result.AsRollBackward;
                await messageHandlers.RollBackwardHandler(rollBackward.Point, rollBackward.Tip);
                break;

            case "forward":
                var block = result.Instance.Result.AsRollForward.Block;
                if (block.HasProperty("height") && block.TryGetProperty("height", out var height) && block.HasProperty("type") && block.TryGetProperty("type", out var type))
                {
                    var blockheight = (long)height.AsNumber;
                    var blocktype = (string)type.AsString ?? "Unknown type";

                    Console.WriteLine($"Processed block height: {blockheight}");
                    await messageHandlers.RollForwardHandler(block, blocktype, result.Instance.Result.AsRollForward.Tip);
                }
                break;

            default:
                Console.WriteLine("Unknown direction or unsupported block direction.");
                break;
        }
    }
}
