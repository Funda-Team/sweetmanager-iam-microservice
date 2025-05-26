namespace IamService.Domain.Model.Queries;

public record GetWorkerAreaByNameAndHotelIdQuery(string Name, int HotelId);