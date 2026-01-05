using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateProtocolParametersService
    {
        Task<OgmiosSchema.QueryLedgerStateProtocolParametersResponseEntity> GetProtocolParametersAsync(
            global::Ogmios.Domain.InteractionContext context,
            OgmiosSchema.QueryLedgerStateProtocolParameters? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}