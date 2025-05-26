using IamService.Domain.Model.Commands.Credential;

namespace IamService.Domain.Services.Credential.Owner;

public interface IOwnerCredentialCommandService
{
    Task<bool> Handle(CreateUserCredentialCommand command);
}