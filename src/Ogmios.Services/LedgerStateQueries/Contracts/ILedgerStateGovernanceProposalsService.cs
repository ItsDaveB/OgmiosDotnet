using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateGovernanceProposalsService
    {
        Task<OgmiosSchema.QueryLedgerStateGovernanceProposalsResponseEntity> GetGovernanceProposalsAsync(OgmiosSchema.QueryLedgerStateGovernanceProposals? request = null, CancellationToken cancellationToken = default);
    }
}