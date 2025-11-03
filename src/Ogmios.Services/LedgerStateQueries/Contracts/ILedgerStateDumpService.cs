using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateDumpService
    {
        Task<OgmiosSchema.QueryLedgerStateDumpResponseEntity> GetDumpAsync(OgmiosSchema.QueryLedgerStateDump? request = null, CancellationToken cancellationToken = default);
    }
}