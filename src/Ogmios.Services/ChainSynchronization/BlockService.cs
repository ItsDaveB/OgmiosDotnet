using System.Text;
using Corvus.Json;
using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public class BlockService(IWebSocketService webSocketService) : IBlockService
{
    private static readonly byte[] NextBlockPrefix = Encoding.UTF8.GetBytes("{\"jsonrpc\":\"2.0\",\"method\":\"nextBlock\",\"id\":\"");
    private static readonly byte[] NextBlockSuffix = Encoding.UTF8.GetBytes("\"}");

    public Task GetNextBlockAsync(Domain.InteractionContext context, MirrorOptions? options = null)
    {
        var requestId = options?.Id ?? string.Empty;
        var idBytes = Encoding.UTF8.GetBytes(requestId);
        var message = new byte[NextBlockPrefix.Length + idBytes.Length + NextBlockSuffix.Length];

        NextBlockPrefix.CopyTo(message, 0);
        idBytes.CopyTo(message, NextBlockPrefix.Length);
        NextBlockSuffix.CopyTo(message, NextBlockPrefix.Length + idBytes.Length);

        return webSocketService.SendMessageAsync(message, context.Socket);
    }

    public async Task HandleNextBlockAsync(string response, IChainSynchronizationMessageHandlers messageHandlers)
    {
        if (string.IsNullOrEmpty(response))
        {
            return;
        }

        var result = ParsedValue<Generated.Ogmios.NextBlockResponse>.Parse(response);
        await ProcessParsedBlockAsync(result, messageHandlers);
    }

    public async Task HandleNextBlockAsync(ReadOnlyMemory<byte> utf8Response, IChainSynchronizationMessageHandlers messageHandlers)
    {
        if (utf8Response.Length == 0)
        {
            return;
        }

        var result = ParsedValue<Generated.Ogmios.NextBlockResponse>.Parse(utf8Response);
        await ProcessParsedBlockAsync(result, messageHandlers);
    }

    private static async Task ProcessParsedBlockAsync(ParsedValue<Generated.Ogmios.NextBlockResponse> result, IChainSynchronizationMessageHandlers messageHandlers)
    {
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
                    if (height.AsNumber % 1000 == 0)
                    {
                        Console.WriteLine($"\u001b[32m {height}\u001b[0m");
                    }
                    await messageHandlers.RollForwardHandler(block, blocktype, result.Instance.Result.AsRollForward.Tip);
                }
                break;

            default:
                Console.WriteLine("Unknown direction or unsupported block direction.");
                break;
        }
    }
}
