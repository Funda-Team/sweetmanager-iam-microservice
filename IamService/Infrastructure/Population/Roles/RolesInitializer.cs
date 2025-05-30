﻿using IamService.Domain.Model.Commands.Role;
using IamService.Domain.Model.Queries;
using IamService.Domain.Services.Roles;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SweetManagerWebService.IAM.Infrastructure.Population.Roles;

public class RolesInitializer(IRoleCommandService roleCommandService,
    IRoleQueryService roleQueryService,
    IWorkerAreaQueryService workerAreaQueryService,
    IamContext context)
{
    public async Task InitializeAsync()
    {
        // Check if the role table is empty

        var result = await roleQueryService.Handle(new GetAllRolesQuery());

        if (!result.Any())
        {
            // Prepopulate the empty table

            await roleCommandService.Handle(new SeedRolesCommand());
        }
    }

}