using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Model.Repositories.Credential;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace IamService.Infrastructure.Persistence.EFC.Repositories.Credential;

public class AdminCredentialRepository(IamContext context) : BaseRepository<AdminCredential>(context), IAdminCredentialRepository
{
    public async Task<AdminCredential?> FindByAdminsIdAsync(int adminsId)
        => await Task.Run(() =>
        (
            from ac in Context.Set<AdminCredential>().ToList()
            where ac.AdminsId == adminsId
            select ac
        ).FirstOrDefault());
}