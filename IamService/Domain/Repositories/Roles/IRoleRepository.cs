using IamService.Domain.Model.Entities.Roles;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Repositories.Roles;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<IEnumerable<Role>> FindAllAsync();

    Task<Role?> FindByName(string name);

    Task<int?> FindIdByName(string name);
}