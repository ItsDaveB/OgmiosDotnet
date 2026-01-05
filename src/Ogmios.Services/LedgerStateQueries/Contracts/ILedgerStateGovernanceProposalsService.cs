
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateGovernanceProposalsService
    {
        Task<OgmiosSchema.QueryLedgerStateGovernanceProposalsResponseEntity> GetGovernanceProposalsAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateGovernanceProposals? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}