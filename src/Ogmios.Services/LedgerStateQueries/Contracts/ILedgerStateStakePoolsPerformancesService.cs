using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateStakePoolsPerformancesService
    {
        Task<OgmiosSchema.QueryLedgerStateStakePoolsPerformancesResponseEntity> GetStakePoolsPerformancesAsync(OgmiosSchema.QueryLedgerStateStakePoolsPerformances? request = null, CancellationToken cancellationToken = default);
    }
}