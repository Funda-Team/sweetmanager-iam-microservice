using IamService.Domain.Model.Commands.Role;

namespace IamService.Domain.Services.Roles;

public interface IWorkerAreaCommandService
{
    Task<bool> Handle(CreateWorkAreaCommand command);

}