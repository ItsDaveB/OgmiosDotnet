
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateTreasuryAndReservesService
    {
        Task<OgmiosSchema.QueryLedgerStateTreasuryAndReservesResponseEntity> GetTreasuryAndReservesAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateTreasuryAndReserves? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}