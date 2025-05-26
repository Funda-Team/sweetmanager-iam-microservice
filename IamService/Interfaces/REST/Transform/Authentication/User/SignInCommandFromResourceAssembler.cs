using IamService.Domain.Model.Commands.Authentication.User;
using IamService.Interfaces.REST.Resource.Authentication.User;

namespace IamService.Interfaces.REST.Transform.Authentication.User;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password, resource.RolesId);
    }
}