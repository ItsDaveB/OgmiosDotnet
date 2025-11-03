using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateRewardsProvenanceService
    {
        Task<OgmiosSchema.QueryLedgerStateRewardsProvenanceResponseEntity> GetRewardsProvenanceAsync(OgmiosSchema.QueryLedgerStateRewardsProvenance? request = null, CancellationToken cancellationToken = default);
    }
}