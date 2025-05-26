using IamService.Domain.Model.Commands.Role;

namespace IamService.Domain.Services.Roles;

public interface IRoleCommandService
{
    Task<bool> Handle(SeedRolesCommand command);
}