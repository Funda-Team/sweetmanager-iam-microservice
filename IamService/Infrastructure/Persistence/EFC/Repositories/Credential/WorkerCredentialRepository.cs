using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Repositories.Credential;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace IamService.Infrastructure.Persistence.EFC.Repositories.Credential;

public class WorkerCredentialRepository(IamContext context) : BaseRepository<WorkerCredential>(context), IWorkerCredentialRepository
{
    public async Task<WorkerCredential?> FindByWorkersIdAsync(int workersId)
        => await Task.Run(() => (
            from wc in Context.Set<WorkerCredential>().ToList()
            where wc.WorkersId.Equals(workersId)
            select wc
        ).FirstOrDefault());
}