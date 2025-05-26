using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Queries;
using IamService.Domain.Repositories.Users;
using IamService.Domain.Services.Users.Worker;

namespace IamService.Application.Internal.QueryServices.User;

public class WorkerQueryService(IWorkerRepository workerRepository) : IWorkerQueryService
{
    public async Task<IEnumerable<Worker>> Handle(GetAllUsersQuery query)
    {
        return await workerRepository.FindAllByHotelId(query.HotelId);
    }

    public async Task<Worker?> Handle(GetUserByIdQuery query)
    {
        return await workerRepository.FindById(query.Id);
    }

    public async Task<Worker?> Handle(GetUserByEmailQuery query)
    {
        return await workerRepository.FindByEmail(query.Email);
    }

    public async Task<int?> Handle(GetUserIdByEmailQuery query)
    {
        return await workerRepository.FindIdByEmail(query.Email);
    }
}