
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateRewardAccountSummariesService
    {
        Task<OgmiosSchema.QueryLedgerStateRewardAccountSummariesResponseEntity> GetRewardAccountSummariesAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateRewardAccountSummaries? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}