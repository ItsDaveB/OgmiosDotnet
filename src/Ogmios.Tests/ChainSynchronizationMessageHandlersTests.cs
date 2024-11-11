using Corvus.Json;
using Generated;
using Moq;
using Ogmios.Services.ChainSynchronization;
using static Generated.Ogmios;

namespace Ogmios.Tests;

public class ChainSynchronizationMessageHandlersTests
{
    private readonly Mock<IChainSynchronizationMessageHandlers> _mockHandlers;
    private readonly IBlockService _blockService;

    public ChainSynchronizationMessageHandlersTests()
    {
        _mockHandlers = new Mock<IChainSynchronizationMessageHandlers>();
        _blockService = new BlockService(new WebSocketService());
    }

    [Fact]
    public async Task HandleNextBlockAsync_CallsRollBackwardHandler_WhenDirectionIsBackward()
    {
        // Arrange
        var direction = (string)NextBlockResponse.ResultEntity.RollBackward.DirectionEntity.EnumValues.Backward ?? string.Empty;
        var response = CreateMockResponse(direction);
        var responseJson = response.AsJsonElement.ToString() ?? string.Empty;
        var rollBackward = response.Result.AsRollBackward;

        _mockHandlers.Setup(h => h.RollBackwardHandler(It.IsAny<PointOrOrigin>(), It.IsAny<TipOrOrigin>()))
                     .Returns(Task.CompletedTask);

        // Act
        await _blockService.HandleNextBlockAsync(responseJson, _mockHandlers.Object);

        // Assert
        _mockHandlers.Verify(h => h.RollBackwardHandler(It.IsAny<PointOrOrigin>(), It.IsAny<TipOrOrigin>()), Times.Once);
    }

    [Fact]
    public async Task HandleNextBlockAsync_CallsRollForwardHandler_WhenDirectionIsForward()
    {
        // Arrange
        var direction = (string)NextBlockResponse.ResultEntity.RollForward.DirectionEntity.EnumValues.Forward ?? string.Empty;
        var response = CreateMockResponse(direction);
        var responseJson = response.AsJsonElement.ToString() ?? string.Empty;
        var rollForward = response.Result.AsRollForward;

        _mockHandlers.Setup(h => h.RollBackwardHandler(It.IsAny<PointOrOrigin>(), It.IsAny<TipOrOrigin>()))
                     .Returns(Task.CompletedTask);
        // Act
        await _blockService.HandleNextBlockAsync(responseJson, _mockHandlers.Object);

        // Assert
        _mockHandlers.Verify(h => h.RollForwardHandler(It.IsAny<Block>(), It.IsAny<string>(), It.IsAny<Tip>()), Times.Once);

    }

    private static NextBlockResponse CreateMockResponse(string direction)
    {

        return direction switch
        {
            "backward" => NextBlockResponse.Create(NextBlockResponse.JsonrpcEntity.EnumValues.V20, NextBlockResponse.MethodEntity.EnumValues.NextBlock,
                                                   NextBlockResponse.ResultEntity.RollBackward.Create(NextBlockResponse.ResultEntity.RollBackward.DirectionEntity.EnumValues.Backward,
                                                   NextBlockResponse.ResultEntity.RollBackward.DefaultInstance.Point, NextBlockResponse.ResultEntity.RollBackward.DefaultInstance.Tip)),
            "forward" => NextBlockResponse.Create(NextBlockResponse.JsonrpcEntity.EnumValues.V20, NextBlockResponse.MethodEntity.EnumValues.NextBlock,
                                                  NextBlockResponse.ResultEntity.RollForward.Create(BlockPraos.FromProperties(new Dictionary<JsonPropertyName, JsonAny> { { new JsonPropertyName("height"), JsonNumber.ParseValue("115545883") }, { new JsonPropertyName("type"), JsonAny.FromAny(BlockPraos.TypeEntity.EnumValues.Praos) } }), NextBlockResponse.ResultEntity.RollForward.DirectionEntity.EnumValues.Forward, NextBlockResponse.ResultEntity.RollForward.DefaultInstance.Tip)),
            _ => throw new ArgumentException("Invalid direction")
        };
    }
}

