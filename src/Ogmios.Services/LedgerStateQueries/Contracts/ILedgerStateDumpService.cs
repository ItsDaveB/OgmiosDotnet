
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateDumpService
    {
        Task<OgmiosSchema.QueryLedgerStateDumpResponseEntity> GetDumpAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateDump? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}