using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateLiveStakeDistributionService
    {
        Task<OgmiosSchema.QueryLedgerStateLiveStakeDistributionResponseEntity> GetLiveStakeDistributionAsync(
            global::Ogmios.Domain.InteractionContext context,
            OgmiosSchema.QueryLedgerStateLiveStakeDistribution? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}