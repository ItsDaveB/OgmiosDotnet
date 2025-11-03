using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateLiveStakeDistributionService
    {
        Task<OgmiosSchema.QueryLedgerStateLiveStakeDistributionResponseEntity> GetLiveStakeDistributionAsync(OgmiosSchema.QueryLedgerStateLiveStakeDistribution? request = null, CancellationToken cancellationToken = default);
    }
}