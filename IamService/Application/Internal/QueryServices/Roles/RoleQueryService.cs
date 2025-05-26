using IamService.Domain.Model.Entities.Roles;
using IamService.Domain.Model.Queries;
using IamService.Domain.Repositories.Roles;
using IamService.Domain.Services.Roles;

namespace IamService.Application.Internal.QueryServices.Roles;

public class RoleQueryService(IRoleRepository roleRepository) : IRoleQueryService
{
    public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery query)
    {
        return await roleRepository.FindAllAsync();
    }

    public async Task<Role?> Handle(GetRoleByNameQuery query)
    {
        return await roleRepository.FindByName(query.Name);
    }

    public async Task<int?> Handle(GetRoleIdByNameQuery query)
    {
        return await roleRepository.FindIdByName(query.Name);
    }
}