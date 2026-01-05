using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateDelegateRepresentativesService
    {
        Task<OgmiosSchema.QueryLedgerStateDelegateRepresentativesResponseEntity> GetDelegateRepresentativesAsync(
            global::Ogmios.Domain.InteractionContext context,
            OgmiosSchema.QueryLedgerStateDelegateRepresentatives? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}