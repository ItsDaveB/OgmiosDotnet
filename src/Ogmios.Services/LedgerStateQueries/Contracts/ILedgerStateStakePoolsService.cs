using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateStakePoolsService
    {
        Task<OgmiosSchema.QueryLedgerStateStakePoolsResponseEntity> GetStakePoolsAsync(
            global::Ogmios.Domain.InteractionContext context,
            OgmiosSchema.QueryLedgerStateStakePools? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}