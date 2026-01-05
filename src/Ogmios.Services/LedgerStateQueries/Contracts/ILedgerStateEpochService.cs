
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateEpochService
    {
        Task<OgmiosSchema.QueryLedgerStateEpochResponseEntity> GetEpochAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateEpoch? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}