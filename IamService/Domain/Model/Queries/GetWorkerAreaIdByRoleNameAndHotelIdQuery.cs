﻿namespace IamService.Domain.Model.Queries;

public record GetWorkerAreaIdByRoleNameAndHotelIdQuery(string Name, int HotelId);