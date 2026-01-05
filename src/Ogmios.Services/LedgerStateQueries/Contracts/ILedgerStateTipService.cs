
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateTipService
    {
        Task<OgmiosSchema.QueryLedgerStateTipResponseEntity> GetTipAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateTip? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}