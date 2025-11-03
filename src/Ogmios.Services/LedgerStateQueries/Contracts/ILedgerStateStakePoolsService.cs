using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateStakePoolsService
    {
        Task<OgmiosSchema.QueryLedgerStateStakePoolsResponseEntity> GetStakePoolsAsync(OgmiosSchema.QueryLedgerStateStakePools? request = null, CancellationToken cancellationToken = default);
    }
}