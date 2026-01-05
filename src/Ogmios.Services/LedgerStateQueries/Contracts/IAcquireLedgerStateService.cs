using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    /// <summary>
    /// Provides access to an Ogmios AcquireLedgerState snapshot for use by ledger-state extractor services.
    /// Implementations may handle acquiring, caching and validating the snapshot so other services read a
    /// consistent view of ledger-state.
    /// </summary>
    public interface IAcquireLedgerStateService
    {
        /// <summary>
        /// Acquire a ledger-state snapshot from Ogmios (AcquireLedgerState) or from cache depending on
        /// implementation details.
        /// </summary>
        Task<OgmiosSchema.AcquireLedgerStateResponseEntity> AcquireAsync(
     global::Ogmios.Domain.InteractionContext context,
     OgmiosSchema.AcquireLedgerState? request = null,
     MirrorOptions? mirrorOptions = null,
     CancellationToken cancellationToken = default);
    }
}
