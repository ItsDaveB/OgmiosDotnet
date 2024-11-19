using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public interface IIntersectionService
{
    Task<Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound> FindIntersectionAsync(Domain.InteractionContext context, StartingPointConfiguration point, MirrorOptions? options = null);
}
