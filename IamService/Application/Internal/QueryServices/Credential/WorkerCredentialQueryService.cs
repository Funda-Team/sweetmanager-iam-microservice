using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Model.Queries;
using IamService.Domain.Repositories.Credential;
using IamService.Domain.Services.Credential.Worker;

namespace SweetManagerWebService.IAM.Application.Internal.QueryServices.Credential;

public class WorkerCredentialQueryService(IWorkerCredentialRepository workerCredentialRepository) : IWorkerCredentialQueryService
{
    public async Task<WorkerCredential?> Handle(GetUserCredentialByIdQuery query)
        => await workerCredentialRepository.FindByWorkersIdAsync(query.UserId);
}