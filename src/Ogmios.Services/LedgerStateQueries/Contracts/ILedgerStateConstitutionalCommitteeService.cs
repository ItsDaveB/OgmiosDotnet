using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateConstitutionalCommitteeService
    {
        Task<OgmiosSchema.QueryLedgerStateConstitutionalCommitteeResponseEntity> GetConstitutionalCommitteeAsync(OgmiosSchema.QueryLedgerStateConstitutionalCommittee? request = null, CancellationToken cancellationToken = default);
    }
}