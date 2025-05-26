using IamService.Domain.Model.Commands.Assignments;

namespace IamService.Domain.Services.Assignments;

public interface IAssignmentWorkerCommandService
{
    Task<bool> Handle(CreateAssignmentWorkerCommand command);
    
}