using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Model.Queries;
using IamService.Domain.Model.Repositories.Credential;
using IamService.Domain.Services.Credential.Admin;

namespace IamService.Application.Internal.QueryServices.Credential;

public class AdminCredentialQueryService(IAdminCredentialRepository adminCredentialRepository): IAdminCredentialQueryService
{
    public async Task<AdminCredential?> Handle(GetUserCredentialByIdQuery query)
        => await adminCredentialRepository.FindByAdminsIdAsync(query.UserId);
}