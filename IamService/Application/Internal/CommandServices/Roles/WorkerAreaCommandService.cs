using IamService.Domain.Model.Commands.Role;
using IamService.Domain.Model.Entities.Roles;
using IamService.Domain.Model.Exceptions;
using IamService.Domain.Model.Queries;
using IamService.Domain.Repositories.Roles;
using IamService.Domain.Services.Roles;
using IamService.Shared.Domain.Repositories;

namespace IamService.Application.Internal.CommandServices.Roles;

public class WorkerAreaCommandService(IUnitOfWork unitOfWork, IWorkerAreaRepository workerAreaRepository, IWorkerAreaQueryService workerAreaQueryService) : IWorkerAreaCommandService
{
    public async Task<bool> Handle(CreateWorkAreaCommand command)
    {
        try
        {
            if (await workerAreaQueryService.Handle(new GetWorkerAreaByNameAndHotelIdQuery(command.Name, command.HotelId)) is
                not null)
                throw new WorkAreaWithTheGivenNameAlreadyExistException();
            
            await workerAreaRepository.AddAsync(new WorkerArea(command.Name));

            await unitOfWork.CommitAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}