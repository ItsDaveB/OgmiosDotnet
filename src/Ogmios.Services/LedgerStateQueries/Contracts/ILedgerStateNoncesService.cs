
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateNoncesService
    {
        Task<OgmiosSchema.QueryLedgerStateNoncesResponseEntity> GetNoncesAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateNonces? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}