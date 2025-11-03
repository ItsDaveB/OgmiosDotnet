using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateRewardAccountSummariesService
    {
        Task<OgmiosSchema.QueryLedgerStateRewardAccountSummariesResponseEntity> GetRewardAccountSummariesAsync(OgmiosSchema.QueryLedgerStateRewardAccountSummaries? request = null, CancellationToken cancellationToken = default);
    }
}