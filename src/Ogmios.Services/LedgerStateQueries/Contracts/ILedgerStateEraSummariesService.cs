using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateEraSummariesService
    {
        Task<OgmiosSchema.QueryLedgerStateEraSummariesResponseEntity> GetEraSummariesAsync(OgmiosSchema.QueryLedgerStateEraSummaries? request = null, CancellationToken cancellationToken = default);
    }
}