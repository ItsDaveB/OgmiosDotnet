
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateProtocolParametersService
    {
        Task<OgmiosSchema.QueryLedgerStateProtocolParametersResponseEntity> GetProtocolParametersAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateProtocolParameters? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}