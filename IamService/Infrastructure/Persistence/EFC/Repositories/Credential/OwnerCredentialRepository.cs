using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Repositories.Credential;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace IamService.Infrastructure.Persistence.EFC.Repositories.Credential;

public class OwnerCredentialRepository(IamContext context): BaseRepository<OwnerCredential>(context),  IOwnerCredentialRepository 
{
    public async Task<OwnerCredential?> FindByOwnersIdAsync(int ownersId)
    => await Task.Run(() => (
            from oc in Context.Set<OwnerCredential>().ToList()
            where oc.OwnersId == ownersId
            select oc
        ).FirstOrDefault());
}