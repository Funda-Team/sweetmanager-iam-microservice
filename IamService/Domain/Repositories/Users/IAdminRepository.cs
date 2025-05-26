using IamService.Domain.Model.Aggregates;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Repositories.Users;

public interface IAdminRepository : IBaseRepository<Admin>
{
    Task<IEnumerable<Admin>> FindAllByHotelId(int hotelId);

    Task<Admin?> FindById(int id);

    Task<Admin?> FindByEmail(string email);

    Task<int?> FindIdByEmail(string email);

    Task<bool> ExecuteUpdateAdminEmailAsync(string email, int id);

    Task<bool> ExecuteUpdateAdminPhoneAsync(int phone, int id);

}