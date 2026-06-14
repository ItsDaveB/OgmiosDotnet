using System.Buffers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Channels;
using Corvus.Json;
using Generated;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using static Generated.Ogmios;

namespace Ogmios.Tests.ChainSynchronization;

public class BlockServiceBufferLifetimeTests
{
    private readonly BlockService _blockService = new(new WebSocketService());

    [Fact]
    public async Task EnqueueBlockHandlersAsync_AttachesResponseBufferToWork()
    {
        var channel = Channel.CreateUnbounded<ChainSyncBlockWork>();
        var message = CreatePooledForwardResponse();

        await _blockService.EnqueueBlockHandlersAsync(message, channel.Writer);
        channel.Writer.TryComplete();

        var work = await channel.Reader.ReadAsync();
        var forward = Assert.IsType<ChainSyncRollForwardWork>(work);

        Assert.Same(message.Buffer, forward.ResponseBuffer.Buffer);
        forward.ResponseBuffer.Return();
    }

    private static PooledWebSocketMessage CreatePooledForwardResponse()
    {
        var response = NextBlockResponse.Create(
            NextBlockResponse.JsonrpcEntity.EnumValues.Value20,
            NextBlockResponse.MethodEntity.EnumValues.NextBlock,
            NextBlockResponse.ResultEntity.RollForward.Create(
                BlockPraos.FromProperties(new Dictionary<JsonPropertyName, JsonAny>
                {
                    { new JsonPropertyName("height"), JsonNumber.ParseValue("115545883") },
                    { new JsonPropertyName("type"), JsonAny.FromAny(BlockPraos.TypeEntity.EnumValues.Praos) }
                }),
                NextBlockResponse.ResultEntity.RollForward.DirectionEntity.EnumValues.Forward,
                NextBlockResponse.ResultEntity.RollForward.DefaultInstance.Tip));

        var json = response.AsJsonElement.ToString() ?? string.Empty;
        var bytes = Encoding.UTF8.GetBytes(json);
        var rented = ArrayPool<byte>.Shared.Rent(bytes.Length);
        Buffer.BlockCopy(bytes, 0, rented, 0, bytes.Length);

        return new PooledWebSocketMessage(rented, bytes.Length, CreateDummyContext());
    }

    private static InteractionContext CreateDummyContext()
    {
        return new InteractionContext
        {
            ConnectionName = "TestConnection",
            StartingPoint = new StartingPointConfiguration
            {
                StartingPointIdOrOrigin = "origin",
                StartingPointSlot = 0
            },
            Connection = new Connection
            {
                Host = "localhost",
                Port = 8080,
                Tls = false,
                MaxPayload = 1024,
                AddressHttp = new Uri("http://localhost:8080"),
                AddressWebSocket = new Uri("ws://localhost:8080")
            },
            Socket = new Moq.Mock<IClientWebSocket>().Object
        };
    }
}
