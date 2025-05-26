using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Model.Queries;

namespace IamService.Domain.Services.Credential.Admin;

public interface IAdminCredentialQueryService
{
    Task<AdminCredential?> Handle(GetUserCredentialByIdQuery query);
    
}