using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateProtocolParametersService
    {
        Task<OgmiosSchema.QueryLedgerStateProtocolParametersResponseEntity> GetProtocolParametersAsync(OgmiosSchema.QueryLedgerStateProtocolParameters? request = null, CancellationToken cancellationToken = default);
    }
}