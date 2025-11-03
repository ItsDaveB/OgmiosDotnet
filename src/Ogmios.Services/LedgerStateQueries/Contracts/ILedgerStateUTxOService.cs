using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateUTxOService
    {
        Task<OgmiosSchema.QueryLedgerStateUtxoResponseEntity> GetUTxOAsync(OgmiosSchema.QueryLedgerStateUtxo? request = null, CancellationToken cancellationToken = default);
    }
}