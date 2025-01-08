using Corvus.Json;
using Generated;
using Ogmios.Domain;
using Ogmios.Domain.Exceptions;

namespace Ogmios.Services.ChainSynchronization;

public class IntersectionService(IWebSocketService webSocketService) : IIntersectionService
{
    public async Task<Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound> FindIntersectionAsync(Domain.InteractionContext context, StartingPointConfiguration point, MirrorOptions? options = null)
    {
        var isFromOrigin = point.StartingPointIdOrOrigin.Equals((string)Origin.EnumValues.Origin.AsString, StringComparison.CurrentCulture);
        var startingPoint = Generated.Ogmios.PointOrOrigin.Point.Create(id: point?.StartingPointIdOrOrigin ?? string.Empty,
                                                                        slot: Slot.ParseValue(point?.StartingPointSlot.ToString() ?? string.Empty));

        var findIntersectionRequest =
        Generated.Ogmios.FindIntersection.Create(jsonrpc: Generated.Ogmios.FindIntersection.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.FindIntersection.MethodEntity.EnumValues.FindIntersection,
                                                 paramsValue: Generated.Ogmios.FindIntersection.ParamsEntity.Create([isFromOrigin ? (string)Origin.EnumValues.Origin.AsString : startingPoint]),
                                                 id: options?.Id ?? string.Empty);

        var responseMessage = await webSocketService.SendAndWaitForResponseAsync(findIntersectionRequest.AsJsonElement.ToString(), context.Socket);
        var responseEntity = ParsedValue<Generated.Ogmios.FindIntersectionResponseEntity>.Parse(responseMessage).Instance;

        if (!responseEntity.IsIntersectionFound)
        {
            throw new IntersectionNotFoundException("No intersection was found for the provided points.");
        }

        return responseEntity.AsIntersectionFound;
    }
}
