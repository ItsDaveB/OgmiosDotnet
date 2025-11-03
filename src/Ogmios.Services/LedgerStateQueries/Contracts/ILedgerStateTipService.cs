using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateTipService
    {
        Task<OgmiosSchema.QueryLedgerStateTipResponseEntity> GetTipAsync(OgmiosSchema.QueryLedgerStateTip? request = null, CancellationToken cancellationToken = default);
    }
}