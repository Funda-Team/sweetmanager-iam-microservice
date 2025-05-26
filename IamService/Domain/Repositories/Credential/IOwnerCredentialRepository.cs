using IamService.Domain.Model.Entities.Credentials;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Repositories.Credential;
    
public interface IOwnerCredentialRepository : IBaseRepository<OwnerCredential>
{
    Task<OwnerCredential?> FindByOwnersIdAsync(int ownersId);
}