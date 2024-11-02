using Ogmios.Domain;
using static Ogmios.Services.ChainSynchronization.BlockService;

namespace Ogmios.Services.ChainSynchronization;

public interface IIntersectionService
{
    Task<Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound> FindIntersectionAsync(Domain.InteractionContext context, IEnumerable<StartingPointConfiguration> points, MirrorOptions? options = null);
}
