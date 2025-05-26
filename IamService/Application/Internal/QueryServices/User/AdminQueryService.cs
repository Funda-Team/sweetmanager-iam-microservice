using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Queries;
using IamService.Domain.Repositories.Users;
using IamService.Domain.Services.Users.Admin;

namespace IamService.Application.Internal.QueryServices.User;

public class AdminQueryService(IAdminRepository adminRepository) : IAdminQueryService
{
    public async Task<IEnumerable<Admin>> Handle(GetAllUsersQuery query)
    {
        return await adminRepository.FindAllByHotelId(query.HotelId);
    }

    public async Task<Admin?> Handle(GetUserByIdQuery query)
    {
        return await adminRepository.FindById(query.Id);
    }

    public async Task<Admin?> Handle(GetUserByEmailQuery query)
    {
        return await adminRepository.FindByEmail(query.Email);
    }

    public async Task<int?> Handle(GetUserIdByEmailQuery query)
    {
        return await adminRepository.FindIdByEmail(query.Email);
    }
}