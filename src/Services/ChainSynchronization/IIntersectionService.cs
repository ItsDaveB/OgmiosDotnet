using Ogmios.Domain.Configuration;
using Ogmios.Services.InteractionContext;
using static Ogmios.Domain.ChainSynchronization.BlockService;

namespace Ogmios.Domain.ChainSynchronization;

public interface IIntersectionService
{
    Task<Generated.Ogmios.FindIntersectionResponseEntity.IntersectionFound> FindIntersectionAsync(InteractionContext context, IEnumerable<StartingPointConfiguration> points, MirrorOptions? options = null);
}
