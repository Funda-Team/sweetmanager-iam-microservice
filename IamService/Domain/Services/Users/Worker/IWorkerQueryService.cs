using IamService.Domain.Model.Queries;

namespace IamService.Domain.Services.Users.Worker;

public interface IWorkerQueryService
{
    Task<IEnumerable<Model.Aggregates.Worker>> Handle(GetAllUsersQuery query);

    Task<Model.Aggregates.Worker?> Handle(GetUserByIdQuery query);

    Task<Model.Aggregates.Worker?> Handle(GetUserByEmailQuery query);

    Task<int?> Handle(GetUserIdByEmailQuery query);

}