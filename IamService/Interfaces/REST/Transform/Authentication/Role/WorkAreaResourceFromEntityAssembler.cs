using IamService.Domain.Model.Entities.Roles;
using IamService.Interfaces.REST.Resource.Authentication.Role;

namespace IamService.Interfaces.REST.Transform.Authentication.Role;

public static class WorkAreaResourceFromEntityAssembler
{
    public static WorkAreaResource ToResourceFromEntity(WorkerArea entity)
    {
        return new(entity.Id, entity.Name);
    }
}