using IamService.Domain.Model.Aggregates;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Repositories.Users;

public interface IOwnerRepository : IBaseRepository<Owner>
{
    Task<Owner?> FindByHotelId(int hotelId);

    Task<Owner?> FindById(int id);

    Task<Owner?> FindByEmail(string email);

    Task<int?> FindIdByEmail(string email);
    
    Task<bool> ExecuteUpdateOwnerEmailAsync(string email, int id);

    Task<bool> ExecuteUpdateOwnerPhoneAsync(int phone, int id);
    
}