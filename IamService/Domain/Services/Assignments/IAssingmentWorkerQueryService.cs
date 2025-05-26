using IamService.Domain.Model.Entities;
using IamService.Domain.Model.Queries;

namespace IamService.Domain.Services.Assignments;

public interface IAssignmentWorkerQueryService
{
    Task<AssignmentWorker?> Handle(GetAssignmentWorkerByIdQuery query);
    
    Task<IEnumerable<AssignmentWorker>> Handle(GetAssignmentWorkerByWorkerIdQuery query);
    
    Task<IEnumerable<AssignmentWorker>> Handle(GetAssignmentWorkerByAdminIdQuery query);
    
    Task<IEnumerable<AssignmentWorker>> Handle(GetAssignmentWorkerByWorkerAreaIdQuery query);

}