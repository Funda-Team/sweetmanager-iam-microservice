using IamService.Domain.Model.Entities.Roles;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Repositories.Roles;

public interface IWorkerAreaRepository : IBaseRepository<WorkerArea>
{
    Task<IEnumerable<WorkerArea>> FindAllAsync(int hotelId);

    Task<WorkerArea?> FindByNameAsync(string name, int hotelId);

    Task<int?> FindIdByNameAsync(string name, int hotelId);

    Task<string?> FindByWorkerIdAsync(int workerId);
    
}