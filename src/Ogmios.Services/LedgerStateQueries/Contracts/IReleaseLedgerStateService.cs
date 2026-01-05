using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface IReleaseLedgerStateService
    {
        Task<OgmiosSchema.ReleaseLedgerStateResponse> ReleaseAsync(
            Domain.InteractionContext context,
            OgmiosSchema.ReleaseLedgerState? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}
