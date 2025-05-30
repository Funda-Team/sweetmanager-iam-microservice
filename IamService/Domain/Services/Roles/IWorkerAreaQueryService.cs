﻿using IamService.Domain.Model.Entities.Roles;
using IamService.Domain.Model.Queries;

namespace IamService.Domain.Services.Roles;

public interface IWorkerAreaQueryService
{
    Task<IEnumerable<WorkerArea>> Handle(GetAllWorkerAreasByHotelIdQuery byHotelIdQuery);
    
    Task<WorkerArea?> Handle(GetWorkerAreaByNameAndHotelIdQuery andHotelIdQuery);

    Task<int?> Handle(GetWorkerAreaIdByRoleNameAndHotelIdQuery andHotelIdQuery);

    Task<string?> Handle(GetWorkerAreaByWorkerId query);
    
}