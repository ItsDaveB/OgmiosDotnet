
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateDelegateRepresentativesService
    {
        Task<OgmiosSchema.QueryLedgerStateDelegateRepresentativesResponseEntity> GetDelegateRepresentativesAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateDelegateRepresentatives? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}