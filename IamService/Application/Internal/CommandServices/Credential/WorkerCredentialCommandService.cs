using IamService.Application.Internal.OutboundServices;
using IamService.Domain.Model.Commands.Credential;
using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Repositories.Credential;
using IamService.Domain.Services.Credential.Worker;
using IamService.Shared.Domain.Repositories;

namespace IamService.Application.Internal.CommandServices.Credential;

public class WorkerCredentialCommandService(IUnitOfWork unitOfWork, 
    IHashingService hashingService, IWorkerCredentialRepository workerCredentialRepository) : IWorkerCredentialCommandService
{
    public async Task<bool> Handle(CreateUserCredentialCommand command)
    {
        try
        {
            var salt = hashingService.CreateSalt();

            var code = hashingService.HashCode(command.Code, salt);

            await workerCredentialRepository.AddAsync(new WorkerCredential(command.UserId, string.Concat(salt, code)));

            await unitOfWork.CommitAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}