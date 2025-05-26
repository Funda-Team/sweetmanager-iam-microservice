using IamService.Domain.Model.Entities.Roles;
using IamService.Domain.Model.Queries;

namespace IamService.Domain.Services.Roles;

public interface IRoleQueryService
{
    Task<IEnumerable<Role>> Handle(GetAllRolesQuery query);

    Task<Role?> Handle(GetRoleByNameQuery query);

    Task<int?> Handle(GetRoleIdByNameQuery query);
    
}