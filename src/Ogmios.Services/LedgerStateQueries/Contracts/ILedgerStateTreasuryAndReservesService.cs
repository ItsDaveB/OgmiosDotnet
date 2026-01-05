using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateTreasuryAndReservesService
    {
        Task<OgmiosSchema.QueryLedgerStateTreasuryAndReservesResponseEntity> GetTreasuryAndReservesAsync(
            global::Ogmios.Domain.InteractionContext context,
            OgmiosSchema.QueryLedgerStateTreasuryAndReserves? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}