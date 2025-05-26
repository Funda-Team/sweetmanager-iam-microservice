using IamService.Domain.Model.Aggregates;
using IamService.Shared.Domain.Repositories;

namespace IamService.Domain.Repositories.Users;

public interface IWorkerRepository : IBaseRepository<Worker>
{
    Task<IEnumerable<Worker>> FindAllByHotelId(int hotelId);

    Task<Worker?> FindById(int id);

    Task<Worker?> FindByEmail(string email);

    Task<int?> FindIdByEmail(string email);
    
    Task<bool> ExecuteUpdateWorkerEmailAsync(string email, int id);

    Task<bool> ExecuteUpdateWorkerPhoneAsync(int phone, int id);
    
}