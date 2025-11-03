using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateOperationalCertificatesService
    {
        Task<OgmiosSchema.QueryLedgerStateOperationalCertificatesResponseEntity> GetOperationalCertificatesAsync(OgmiosSchema.QueryLedgerStateOperationalCertificates? request = null, CancellationToken cancellationToken = default);
    }
}