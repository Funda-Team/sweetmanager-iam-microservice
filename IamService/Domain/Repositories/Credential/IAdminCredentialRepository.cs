using IamService.Domain.Model.Entities.Credentials;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Model.Repositories.Credential;

public interface IAdminCredentialRepository : IBaseRepository<AdminCredential>
{
    Task<AdminCredential?> FindByAdminsIdAsync(int adminsId);
}