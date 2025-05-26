using IamService.Domain.Model.Entities.Credentials;

using IamService.Domain.Model.Queries;
namespace IamService.Domain.Services.Credential.Worker;

public interface IWorkerCredentialQueryService
{
    Task<WorkerCredential?> Handle(GetUserCredentialByIdQuery query);
    
}