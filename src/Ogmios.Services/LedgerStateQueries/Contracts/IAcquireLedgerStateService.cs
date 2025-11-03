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
        /// <param name="request">Optional AcquireLedgerState request entity (will be forwarded to Ogmios where applicable).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The raw AcquireLedgerState response entity as produced by the generated Ogmios schema types.</returns>
        Task<OgmiosSchema.AcquireLedgerStateResponseEntity> AcquireAsync(OgmiosSchema.AcquireLedgerState? request = null);
    }
}
