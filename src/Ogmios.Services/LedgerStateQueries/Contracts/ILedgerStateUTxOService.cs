
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateUTxOService
    {
        Task<OgmiosSchema.QueryLedgerStateUtxoResponseEntity> GetUTxOAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateUtxo? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}