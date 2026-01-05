using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateStakePoolsPerformancesService
    {
        Task<OgmiosSchema.QueryLedgerStateStakePoolsPerformancesResponseEntity> GetStakePoolsPerformancesAsync(
            global::Ogmios.Domain.InteractionContext context,
            OgmiosSchema.QueryLedgerStateStakePoolsPerformances? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}