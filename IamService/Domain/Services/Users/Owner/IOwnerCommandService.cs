using IamService.Domain.Model.Commands.Authentication.User;

namespace IamService.Domain.Services.Users.Owner;

public interface IOwnerCommandService
{
    Task<bool> Handle(SignUpUserCommand command);

    Task<bool> Handle(UpdateUserCommand command);

    Task<dynamic?> Handle(SignInCommand command);
    
}