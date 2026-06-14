using System.Text;
using System.Threading.Channels;
using Corvus.Json;
using Generated;
using Microsoft.Extensions.Logging;
using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public class BlockService(IWebSocketService webSocketService, ILogger<BlockService>? logger = null) : IBlockService
{
    private readonly ILogger<BlockService>? _logger = logger;
    private static readonly byte[] NextBlockMessage = Encoding.UTF8.GetBytes("{\"jsonrpc\":\"2.0\",\"method\":\"nextBlock\"}");
    private static readonly byte[] NextBlockPrefix = Encoding.UTF8.GetBytes("{\"jsonrpc\":\"2.0\",\"method\":\"nextBlock\",\"id\":\"");
    private static readonly byte[] NextBlockSuffix = Encoding.UTF8.GetBytes("\"}");

    public Task GetNextBlockAsync(Domain.InteractionContext context, MirrorOptions? options = null)
    {
        if (options?.Id is { Length: > 0 } requestId)
        {
            var idBytes = Encoding.UTF8.GetBytes(requestId);
            var message = new byte[NextBlockPrefix.Length + idBytes.Length + NextBlockSuffix.Length];
            NextBlockPrefix.CopyTo(message, 0);
            idBytes.CopyTo(message, NextBlockPrefix.Length);
            NextBlockSuffix.CopyTo(message, NextBlockPrefix.Length + idBytes.Length);
            return webSocketService.SendMessageAsync(message, context.Socket);
        }

        return webSocketService.SendMessageAsync(NextBlockMessage, context.Socket);
    }

    public async Task HandleNextBlockAsync(string response, IChainSynchronizationMessageHandlers messageHandlers)
    {
        if (string.IsNullOrEmpty(response))
        {
            return;
        }

        var result = ParsedValue<Generated.Ogmios.NextBlockResponse>.Parse(response);
        await DispatchParsedBlockAsync(result, messageHandlers).ConfigureAwait(false);
    }

    public async Task HandleNextBlockAsync(ReadOnlyMemory<byte> utf8Response, IChainSynchronizationMessageHandlers messageHandlers)
    {
        if (utf8Response.Length == 0)
        {
            return;
        }

        var result = ParsedValue<Generated.Ogmios.NextBlockResponse>.Parse(utf8Response);
        await DispatchParsedBlockAsync(result, messageHandlers).ConfigureAwait(false);
    }

    public async ValueTask EnqueueBlockHandlersAsync(ReadOnlyMemory<byte> utf8Response, ChannelWriter<ChainSyncBlockWork> writer, CancellationToken cancellationToken = default)
    {
        if (utf8Response.Length == 0)
        {
            return;
        }

        var result = ParsedValue<Generated.Ogmios.NextBlockResponse>.Parse(utf8Response);
        await EnqueueParsedBlockAsync(result, writer, cancellationToken).ConfigureAwait(false);
    }

    private async Task DispatchParsedBlockAsync(ParsedValue<Generated.Ogmios.NextBlockResponse> result, IChainSynchronizationMessageHandlers messageHandlers)
    {
        if (!TryCreateBlockWork(result, out var work))
        {
            return;
        }

        switch (work)
        {
            case ChainSyncRollBackwardWork rollback:
                await messageHandlers.RollBackwardHandler(rollback.Point, rollback.Tip).ConfigureAwait(false);
                break;
            case ChainSyncRollForwardWork forward:
                await messageHandlers.RollForwardHandler(forward.Block, forward.BlockType, forward.Tip).ConfigureAwait(false);
                break;
        }
    }

    private async ValueTask EnqueueParsedBlockAsync(
        ParsedValue<Generated.Ogmios.NextBlockResponse> result,
        ChannelWriter<ChainSyncBlockWork> writer,
        CancellationToken cancellationToken)
    {
        if (!TryCreateBlockWork(result, out var work))
        {
            return;
        }

        await writer.WriteAsync(work, cancellationToken).ConfigureAwait(false);
    }

    private bool TryCreateBlockWork(ParsedValue<Generated.Ogmios.NextBlockResponse> result, out ChainSyncBlockWork work)
    {
        work = null!;

        if (!result.Instance.Result.TryGetProperty("direction", out var direction))
        {
            return false;
        }

        switch ((string)direction.AsString)
        {
            case "backward":
                var rollBackward = result.Instance.Result.AsRollBackward;
                work = new ChainSyncRollBackwardWork(rollBackward.Point, rollBackward.Tip);
                return true;

            case "forward":
                var block = result.Instance.Result.AsRollForward.Block;
                if (block.HasProperty("height") && block.TryGetProperty("height", out _) && block.HasProperty("type") && block.TryGetProperty("type", out var type))
                {
                    var blocktype = (string)type.AsString ?? "Unknown type";
                    work = new ChainSyncRollForwardWork(block, blocktype, result.Instance.Result.AsRollForward.Tip);
                    return true;
                }

                return false;

            default:
                _logger?.LogDebug("Unknown or unsupported block direction: {Direction}", direction.AsString);
                return false;
        }
    }
}
