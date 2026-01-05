
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateProposedProtocolParametersService
    {
        Task<OgmiosSchema.QueryLedgerStateProposedProtocolParametersResponseEntity> GetProposedProtocolParametersAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateProposedProtocolParameters? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}