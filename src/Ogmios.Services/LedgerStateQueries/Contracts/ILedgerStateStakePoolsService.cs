
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateStakePoolsService
    {
        Task<OgmiosSchema.QueryLedgerStateStakePoolsResponseEntity> GetStakePoolsAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateStakePools? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}