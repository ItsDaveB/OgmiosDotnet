using Corvus.Json;
using Generated;
using Ogmios.Domain;
using Ogmios.Domain.Exceptions;
using static Ogmios.Services.ChainSynchronization.BlockService;

namespace Ogmios.Services.ChainSynchronization;

public class IntersectionService(IWebSocketService webSocketService) : IIntersectionService
{
    public async Task<Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound> FindIntersectionAsync(Domain.InteractionContext context, StartingPointConfiguration point, MirrorOptions? options = null)
    {
        var isFromOrigin = point.StartingPointIdOrOrigin.Equals((string)Origin.EnumValues.Origin.AsString, StringComparison.CurrentCulture);
        var startingPoint = Generated.Ogmios.PointOrOrigin.Point.Create(id: point?.StartingPointIdOrOrigin ?? string.Empty,
                                                                        slot: Slot.ParseValue(point?.StartingPointSlot.ToString() ?? string.Empty));

        var findIntersectionRequest =
        Generated.Ogmios.FindIntersection.Create(jsonrpc: Generated.Ogmios.FindIntersection.JsonrpcEntity.EnumValues.V20, method: Generated.Ogmios.FindIntersection.MethodEntity.EnumValues.FindIntersection,
                                                 paramsEntity: Generated.Ogmios.FindIntersection.ParamsEntity.Create([isFromOrigin ? (string)Origin.EnumValues.Origin.AsString : startingPoint]),
                                                 id: options?.Id ?? string.Empty);

        var jsonResponse = await webSocketService.SendAndWaitForResponseAsync(findIntersectionRequest.AsJsonElement.ToString(), context.Socket);
        var response = ParsedValue<Generated.Ogmios.FindIntersectionResponseEntity>.Parse(jsonResponse);

        if (!response.Instance.IsIntersectionFound)
        {
            throw new IntersectionNotFoundException("No intersection was found for the provided points.");
        }

        return response.Instance.AsIntersectionFound;
    }
}
