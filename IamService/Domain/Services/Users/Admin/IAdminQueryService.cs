using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Queries;

namespace IamService.Domain.Services.Users.Admin;

public interface IAdminQueryService
{
    Task<IEnumerable<Model.Aggregates.Admin>> Handle(GetAllUsersQuery query);

    Task<Model.Aggregates.Admin?> Handle(GetUserByIdQuery query);

    Task<Model.Aggregates.Admin?> Handle(GetUserByEmailQuery query);

    Task<int?> Handle(GetUserIdByEmailQuery query);
    
}