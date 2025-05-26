using IamService.Domain.Model.Queries;

namespace IamService.Domain.Services.Users.Owner;

public interface IOwnerQueryService
{
    Task<Model.Aggregates.Owner?> Handle(GetAllUsersQuery query);

    Task<Model.Aggregates.Owner?> Handle(GetUserByIdQuery query);

    Task<Model.Aggregates.Owner?> Handle(GetUserByEmailQuery query);

    Task<int?> Handle(GetUserIdByEmailQuery query);
    
}