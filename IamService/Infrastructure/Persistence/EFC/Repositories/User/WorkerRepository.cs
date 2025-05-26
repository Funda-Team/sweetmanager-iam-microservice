using IamService.Domain.Model.Aggregates;
using IamService.Domain.Repositories.Users;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IamService.Infrastructure.Persistence.EFC.Repositories.User;

public class WorkerRepository(IamContext context) : BaseRepository<Worker>(context), IWorkerRepository
{
    public async Task<IEnumerable<Worker>> FindAllByHotelId(int hotelId)
        => await Task.Run(() => (
            from wo in Context.Set<Worker>().ToList()
            where wo.HotelsId.Equals(hotelId)
            select wo
        ).ToList());

    public async Task<Worker?> FindById(int id)
        => await Task.Run(() => (
            from wo in Context.Set<Worker>().ToList()
            where wo.Id.Equals(id)
            select wo
        ).FirstOrDefault());

    public async Task<Worker?> FindByEmail(string email)
        => await Task.Run(() => (
            from wo in Context.Set<Worker>().ToList()
            where wo.Email.Equals(email)
            select wo
        ).FirstOrDefault()); 

    public async Task<int?> FindIdByEmail(string email)
        => await Task.Run(() => (
            from wo in Context.Set<Worker>().ToList()
            where wo.Email.Equals(email)
            select wo.Id
        ).FirstOrDefault());

    public async Task<bool> ExecuteUpdateWorkerEmailAsync(string email, int id)
        => await Context.Set<Worker>().Where(w => w.Id.Equals(id))
            .ExecuteUpdateAsync(w => w.SetProperty(p => p.Email, email)) > 0;

    public async Task<bool> ExecuteUpdateWorkerPhoneAsync(int phone, int id)
        => await Context.Set<Worker>().Where(w => w.Id.Equals(id))
            .ExecuteUpdateAsync(w => w.SetProperty(p => p.Phone, phone)) > 0;
}