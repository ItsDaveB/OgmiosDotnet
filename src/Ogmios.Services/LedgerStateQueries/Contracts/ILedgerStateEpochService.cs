using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateEpochService
    {
        Task<OgmiosSchema.QueryLedgerStateEpochResponseEntity> GetEpochAsync(OgmiosSchema.QueryLedgerStateEpoch? request = null, CancellationToken cancellationToken = default);
    }
}