using IamService.Domain.Model.Aggregates;
using IamService.Domain.Repositories.Users;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IamService.Infrastructure.Persistence.EFC.Repositories.User;

public class AdminRepository(IamContext context) : BaseRepository<Admin>(context), IAdminRepository
{
    public async Task<IEnumerable<Admin>> FindAllByHotelId(int hotelId)
        => await Task.Run(() => (
            from ad in Context.Set<Admin>().ToList()
            where ad.HotelsId.Equals(hotelId)
            select ad
        ).ToList());


    public async Task<Admin?> FindById(int id)
        => await Task.Run(() => (
            from ad in Context.Set<Admin>().ToList()
            where ad.Id.Equals(id)
            select ad
        ).FirstOrDefault());

    public async Task<Admin?> FindByEmail(string email)
        => await Task.Run(() => (
            from ad in Context.Set<Admin>().ToList()
            where ad.Email.Equals(email)
            select ad
        ).FirstOrDefault());

    public async Task<int?> FindIdByEmail(string email)
        => await Task.Run(() => (
            from ad in Context.Set<Admin>().ToList()
            where ad.Email.Equals(email)
                select ad.Id
        ).FirstOrDefault());

    public async Task<bool> ExecuteUpdateAdminEmailAsync(string email, int id)
        => await Context.Set<Admin>().Where(a => a.Id == id).
            ExecuteUpdateAsync(ad => ad.SetProperty(p => p.Email, email)) > 0;

    public async Task<bool> ExecuteUpdateAdminPhoneAsync(int phone, int id)
        => await Context.Set<Admin>().Where(a => a.Id == id)
            .ExecuteUpdateAsync(a => a.SetProperty(p => p.Phone, phone)) > 0;
}