using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Entities;
using IamService.Domain.Model.Repositories.Assignments;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.Assignment;

public class AssignmentWorkerRepository(IamContext context) : BaseRepository<AssignmentWorker>(context), IAssignmentWorkerRepository
{

    public async Task<IEnumerable<AssignmentWorker>> FindByWorkerIdAsync(int workerId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            join wk in Context.Set<Worker>().ToList() on aw.WorkersId equals wk.Id
            where wk.Id.Equals(workerId) && aw.FinalDate > DateTime.Now
            select aw
        ).ToList());

    public async Task<IEnumerable<AssignmentWorker>> FindByAdminIdAsync(int adminId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            where aw.AdminsId.Equals(adminId)
            select aw
        ).ToList());

    public async Task<IEnumerable<AssignmentWorker>> FindByWorkerAreaIdAsync(int workerAreaId)
        => await Task.Run(() => (
            from aw in Context.Set<AssignmentWorker>().ToList()
            where aw.WorkerAreasId.Equals(workerAreaId)
            select aw
        ).ToList());

}