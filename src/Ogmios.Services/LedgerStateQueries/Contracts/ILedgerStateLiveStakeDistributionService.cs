
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateLiveStakeDistributionService
    {
        Task<OgmiosSchema.QueryLedgerStateLiveStakeDistributionResponseEntity> GetLiveStakeDistributionAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateLiveStakeDistribution? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}