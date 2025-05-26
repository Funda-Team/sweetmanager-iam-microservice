using IamService.Domain.Model.Aggregates;
using IamService.Domain.Repositories.Users;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IamService.Infrastructure.Persistence.EFC.Repositories.User;

public class OwnerRepository(IamContext context) : BaseRepository<Owner>(context), IOwnerRepository
{
    public async Task<Owner?> FindByHotelId(int hotelId)
        => await Task.Run(() => (
            from ow in Context.Set<Owner>().ToList()
            where ow.HotelsId.Equals(hotelId)
            select ow
        ).FirstOrDefault());

    public async Task<Owner?> FindById(int id)
        => await Task.Run(() => (
            from ow in Context.Set<Owner>().ToList()
            where ow.Id.Equals(id)
            select ow
        ).FirstOrDefault());


    public async Task<Owner?> FindByEmail(string email)
        => await Task.Run(() => (
            from ow in Context.Set<Owner>().ToList()
            where ow.Email.Equals(email)
            select ow
        ).FirstOrDefault());

    public async Task<int?> FindIdByEmail(string email)
        => await Task.Run(() => (
            from ow in Context.Set<Owner>().ToList()
            where ow.Email.Equals(email)
            select ow.Id
        ).FirstOrDefault());

    public async Task<bool> ExecuteUpdateOwnerEmailAsync(string email, int id)
        => await Context.Set<Owner>().Where(o => o.Id == id)
            .ExecuteUpdateAsync(o => o.SetProperty(p => p.Email, email)) > 0;

    public async Task<bool> ExecuteUpdateOwnerPhoneAsync(int phone, int id)
        => await Context.Set<Owner>().Where(o => o.Id == id)
            .ExecuteUpdateAsync(o => o.SetProperty(p => p.Phone, phone)) > 0;
    
}