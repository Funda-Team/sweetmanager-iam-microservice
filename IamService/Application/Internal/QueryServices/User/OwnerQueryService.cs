﻿using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Queries;
using IamService.Domain.Repositories.Users;
using IamService.Domain.Services.Users.Owner;

namespace IamService.Application.Internal.QueryServices.User;

public class OwnerQueryService(IOwnerRepository ownerRepository) : IOwnerQueryService
{
    public async Task<Owner?> Handle(GetAllUsersQuery query)
    {
        return await ownerRepository.FindByHotelId(query.HotelId);
    }

    public async Task<Owner?> Handle(GetUserByIdQuery query)
    {
        var owner = await ownerRepository.FindById(query.Id);

        if (owner is null)
            throw new Exception("The given Id doesnt correspond with any owner");

        return owner;
    }

    public async Task<Owner?> Handle(GetUserByEmailQuery query)
    {
        return await ownerRepository.FindByEmail(query.Email);
    }

    public async Task<int?> Handle(GetUserIdByEmailQuery query)
    {
        return await ownerRepository.FindIdByEmail(query.Email);
    }
}