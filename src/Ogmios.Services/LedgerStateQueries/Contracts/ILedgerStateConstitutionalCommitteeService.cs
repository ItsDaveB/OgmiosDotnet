
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateConstitutionalCommitteeService
    {
        Task<OgmiosSchema.QueryLedgerStateConstitutionalCommitteeResponseEntity> GetConstitutionalCommitteeAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateConstitutionalCommittee? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}