using Corvus.Json;
using Ogmios.Domain;


namespace Ogmios.Services.ChainSynchronization;

public class BlockService(IWebSocketService webSocketService) : IBlockService
{
    public Task GetNextBlockAsync(Domain.InteractionContext context, MirrorOptions? options = null)
    {
        var nextBlockRequest = Generated.Ogmios.NextBlock.Create(jsonrpc: Generated.Ogmios.NextBlock.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.NextBlock.MethodEntity.EnumValues.NextBlock, id: options?.Id ?? string.Empty);
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
                    var blocktype = (string)type.AsString ?? "Unknown type";
                    await messageHandlers.RollForwardHandler(block, blocktype, result.Instance.Result.AsRollForward.Tip);
                }
                break;

            default:
                Console.WriteLine("Unknown direction or unsupported block direction.");
                break;
        }
    }
}
