using IamService.Domain.Model.Commands.Credential;

namespace IamService.Domain.Services.Credential.Worker;

public interface IWorkerCredentialCommandService
{
    Task<bool> Handle(CreateUserCredentialCommand command);
}