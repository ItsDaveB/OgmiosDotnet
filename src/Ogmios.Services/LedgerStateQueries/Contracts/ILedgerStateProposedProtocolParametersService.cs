
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateProposedProtocolParametersService
    {
        Task<OgmiosSchema.QueryLedgerStateProtocolParametersResponseEntity> GetProposedProtocolParametersAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateProtocolParameters? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}