using IamService.Domain.Model.Entities.Roles;
using IamService.Domain.Repositories.Roles;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace IamService.Infrastructure.Persistence.EFC.Repositories.Roles;

public class RoleRepository(IamContext context) : BaseRepository<Role>(context) , IRoleRepository
{
    public async Task<IEnumerable<Role>> FindAllAsync()
        => await Task.Run(() => (
            from rl in Context.Set<Role>().ToList()
            select rl
        ).ToList());

    public async Task<Role?> FindByName(string name)
        => await Task.Run(() => (
            from rl in Context.Set<Role>().ToList()
            where rl.Name.Equals(name)
            select rl
        ).FirstOrDefault());
    
    public async Task<int?> FindIdByName(string name)
        => await Task.Run(() => (
            from rl in Context.Set<Role>().ToList()
            where rl.Name.Equals(name)
            select rl.Id
        ).FirstOrDefault());

}