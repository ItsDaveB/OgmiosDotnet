using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateNoncesService
    {
        Task<OgmiosSchema.QueryLedgerStateNoncesResponseEntity> GetNoncesAsync(OgmiosSchema.QueryLedgerStateNonces? request = null, CancellationToken cancellationToken = default);
    }
}