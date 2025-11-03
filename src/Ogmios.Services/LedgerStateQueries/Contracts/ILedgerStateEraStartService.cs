using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateEraStartService
    {
        Task<OgmiosSchema.QueryLedgerStateEraStartResponseEntity> GetEraStartAsync(OgmiosSchema.QueryLedgerStateEraStart? request = null, CancellationToken cancellationToken = default);
    }
}