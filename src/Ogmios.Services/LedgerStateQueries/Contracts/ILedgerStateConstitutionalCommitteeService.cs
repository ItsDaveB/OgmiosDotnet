using Ogmios.Domain;
using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateConstitutionalCommitteeService
    {
        Task<OgmiosSchema.QueryLedgerStateConstitutionalCommitteeResponseEntity> GetConstitutionalCommitteeAsync(
            global::Ogmios.Domain.InteractionContext context,
            OgmiosSchema.QueryLedgerStateConstitutionalCommittee? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}