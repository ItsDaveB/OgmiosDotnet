
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateOperationalCertificatesService
    {
        Task<OgmiosSchema.QueryLedgerStateOperationalCertificatesResponseEntity> GetOperationalCertificatesAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateOperationalCertificates? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}