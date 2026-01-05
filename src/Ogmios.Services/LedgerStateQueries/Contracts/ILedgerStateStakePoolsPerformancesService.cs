
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateStakePoolsPerformancesService
    {
        Task<OgmiosSchema.QueryLedgerStateStakePoolsPerformancesResponseEntity> GetStakePoolsPerformancesAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateStakePoolsPerformances? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}