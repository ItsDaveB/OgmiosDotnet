using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateRewardAccountSummariesService
    {
        Task<OgmiosSchema.QueryLedgerStateRewardAccountSummariesResponseEntity> GetRewardAccountSummariesAsync(
            global::Ogmios.Domain.InteractionContext context,
            OgmiosSchema.QueryLedgerStateRewardAccountSummaries? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}