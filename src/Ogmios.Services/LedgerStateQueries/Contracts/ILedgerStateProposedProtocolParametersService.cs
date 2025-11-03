using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateProposedProtocolParametersService
    {
        Task<OgmiosSchema.QueryLedgerStateProposedProtocolParametersResponseEntity> GetProposedProtocolParametersAsync(OgmiosSchema.QueryLedgerStateProposedProtocolParameters? request = null, CancellationToken cancellationToken = default);
    }
}