using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateProjectedRewardsService
    {
        Task<OgmiosSchema.QueryLedgerStateProjectedRewardsResponseEntity> GetProjectedRewardsAsync(OgmiosSchema.QueryLedgerStateProjectedRewards? request = null, CancellationToken cancellationToken = default);
    }
}