using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Entities;
using IamService.Domain.Model.Entities.Roles;
using IamService.Domain.Repositories.Roles;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace IamService.Infrastructure.Persistence.EFC.Repositories.Roles;

public class WorkerAreaRepository(IamContext context) : BaseRepository<WorkerArea>(context), IWorkerAreaRepository
{
    public async Task<IEnumerable<WorkerArea>> FindAllAsync(int hotelId)
        => await Task.Run(() => (
            from wa in Context.Set<WorkerArea>().ToList()
            where wa.HotelId.Equals(hotelId)
            select wa
        ).ToList());

    public async Task<WorkerArea?> FindByNameAsync(string name, int hotelId)
        => await Task.Run(() => (
            from wa in Context.Set<WorkerArea>().ToList()
            where wa.Name.Equals(name) && wa.HotelId.Equals(hotelId)
            select wa
        ).FirstOrDefault());

    public async Task<int?> FindIdByNameAsync(string name, int hotelId)
        => await Task.Run(() => (
            from wa in Context.Set<WorkerArea>().ToList()
            where wa.Name.Equals(name) && wa.HotelId.Equals(hotelId)
            select wa.Id
        ).FirstOrDefault());

    public async Task<string?> FindByWorkerIdAsync(int workerId)
    {
        Task<string?> queryAsync = new(() => (
            from wo in Context.Set<Worker>().ToList()
            join ass in Context.Set<AssignmentWorker>().ToList()
                on wo.Id equals ass.WorkersId
            join wor in Context.Set<WorkerArea>().ToList()
                on ass.WorkerAreasId equals wor.Id
            where wo.Id.Equals(workerId) && ass.FinalDate > DateTime.Now
            select wor.Name 
        ).FirstOrDefault());
        
        queryAsync.Start();

        var result = await queryAsync;

        return result;
    }
}