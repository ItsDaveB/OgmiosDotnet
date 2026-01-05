
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateRewardsProvenanceService
    {
        Task<OgmiosSchema.QueryLedgerStateRewardsProvenanceResponseEntity> GetRewardsProvenanceAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateRewardsProvenance? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}