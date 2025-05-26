using IamService.Domain.Model.Commands.Credential;

namespace IamService.Domain.Services.Credential.Admin;

public interface IAdminCredentialCommandService
{
    Task<bool> Handle(CreateUserCredentialCommand command);
    
}