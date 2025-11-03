using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateDelegateRepresentativesService
    {
        Task<OgmiosSchema.QueryLedgerStateDelegateRepresentativesResponseEntity> GetDelegateRepresentativesAsync(OgmiosSchema.QueryLedgerStateDelegateRepresentatives? request = null, CancellationToken cancellationToken = default);
    }
}