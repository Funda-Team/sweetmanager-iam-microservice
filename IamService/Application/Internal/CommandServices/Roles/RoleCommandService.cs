using IamService.Domain.Model.Commands.Role;
using IamService.Domain.Model.Entities.Roles;
using IamService.Domain.Model.ValueObjects;
using IamService.Domain.Repositories.Roles;
using IamService.Domain.Services.Roles;
using IamService.Shared.Domain.Repositories;

namespace IamService.Application.Internal.CommandServices.Roles;

public class RoleCommandService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IRoleCommandService
{
    public async Task<bool> Handle(SeedRolesCommand command)
    {
        foreach (var role in Enum.GetValues(typeof(ERoles)))
        {
            if (await roleRepository.FindByName(role.ToString()!) is null)
            {
                await roleRepository.AddAsync(new Role(role.ToString()!));
            }
        }

        await unitOfWork.CommitAsync();

        return true;
    }
}