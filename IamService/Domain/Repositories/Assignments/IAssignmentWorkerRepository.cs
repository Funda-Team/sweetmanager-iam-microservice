using IamService.Domain.Model.Entities;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Model.Repositories.Assignments;

public interface IAssignmentWorkerRepository : IBaseRepository<AssignmentWorker>
{
    
    Task<IEnumerable<AssignmentWorker>> FindByWorkerIdAsync(int workerId);

    Task<IEnumerable<AssignmentWorker>> FindByAdminIdAsync(int adminId);

    Task<IEnumerable<AssignmentWorker>> FindByWorkerAreaIdAsync(int workerAreaId);
    
}