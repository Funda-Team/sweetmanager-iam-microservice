using IamService.Domain.Model.Entities.Credentials;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Repositories.Credential;

public interface IWorkerCredentialRepository : IBaseRepository<WorkerCredential>
{
    Task<WorkerCredential?> FindByWorkersIdAsync(int workersId);
    
}