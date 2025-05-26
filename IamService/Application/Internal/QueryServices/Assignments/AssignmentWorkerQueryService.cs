using IamService.Domain.Model.Entities;
using IamService.Domain.Model.Queries;
using IamService.Domain.Model.Repositories.Assignments;
using IamService.Domain.Services.Assignments;

namespace IamService.Application.Internal.QueryServices.Assignments;

public class AssignmentWorkerQueryService(IAssignmentWorkerRepository assignmentWorkerRepository) : IAssignmentWorkerQueryService
{
    public async Task<AssignmentWorker?> Handle(GetAssignmentWorkerByIdQuery query)
    {
        return await assignmentWorkerRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<AssignmentWorker>> Handle(GetAssignmentWorkerByWorkerIdQuery query)
    {
        return await assignmentWorkerRepository.FindByWorkerIdAsync(query.WorkerId);
    }
    
    public async Task<IEnumerable<AssignmentWorker>> Handle(GetAssignmentWorkerByAdminIdQuery query)
    {
        return await assignmentWorkerRepository.FindByAdminIdAsync(query.AdminId);
    }
    
    public async Task<IEnumerable<AssignmentWorker>> Handle(GetAssignmentWorkerByWorkerAreaIdQuery query)
    {
        return await assignmentWorkerRepository.FindByWorkerAreaIdAsync(query.WorkerAreaId);
    }
    
    
    
}