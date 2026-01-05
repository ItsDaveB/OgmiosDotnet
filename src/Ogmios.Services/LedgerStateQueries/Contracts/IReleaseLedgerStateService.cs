
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface IReleaseLedgerStateService
    {
        Task<OgmiosSchema.ReleaseLedgerStateResponse> ReleaseAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.ReleaseLedgerState? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}
