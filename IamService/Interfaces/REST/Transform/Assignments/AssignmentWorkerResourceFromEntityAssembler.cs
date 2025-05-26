using IamService.Domain.Model.Entities;
using IamService.Interfaces.REST.Resource.Assignments;

namespace IamService.Interfaces.REST.Transform.Assignments;

public static class AssignmentWorkerResourceFromEntityAssembler
{
    public static AssignmentWorkerResource ToResourceFromEntity(AssignmentWorker entity)
    {
        return new AssignmentWorkerResource(entity.Id, entity.WorkerAreasId, entity.WorkersId, entity.AdminsId,
            entity.StartDate, entity.FinalDate, entity.State);
    }
}