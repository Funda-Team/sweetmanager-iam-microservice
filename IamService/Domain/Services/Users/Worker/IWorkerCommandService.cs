using IamService.Domain.Model.Commands.Authentication.User;

namespace IamService.Domain.Services.Users.Worker;

public interface IWorkerCommandService
{
    Task<bool> Handle(SignUpUserCommand command);

    Task<bool> Handle(UpdateUserCommand command);

    Task<dynamic?> Handle(SignInCommand command);
    
}