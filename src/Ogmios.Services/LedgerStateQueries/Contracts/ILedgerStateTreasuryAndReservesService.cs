using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateTreasuryAndReservesService
    {
        Task<OgmiosSchema.QueryLedgerStateTreasuryAndReservesResponseEntity> GetTreasuryAndReservesAsync(OgmiosSchema.QueryLedgerStateTreasuryAndReserves? request = null, CancellationToken cancellationToken = default);
    }
}