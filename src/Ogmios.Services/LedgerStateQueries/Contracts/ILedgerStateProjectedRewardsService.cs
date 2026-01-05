
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateProjectedRewardsService
    {
        Task<OgmiosSchema.QueryLedgerStateProjectedRewardsResponseEntity> GetProjectedRewardsAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateProjectedRewards? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}