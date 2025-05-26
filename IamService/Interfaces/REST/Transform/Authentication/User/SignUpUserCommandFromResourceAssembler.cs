using IamService.Domain.Model.Commands.Authentication.User;
using IamService.Interfaces.REST.Resource.Authentication.User;

namespace IamService.Interfaces.REST.Transform.Authentication.User;

public static class SignUpUserCommandFromResourceAssembler
{
    public static SignUpUserCommand ToCommandFromResource(SignUpUserResource resource)
    {
        return new(resource.Id,  resource.Username, resource.Name, resource.Surname, resource.Email,
            resource.Phone, resource.State, resource.Password, resource.HotelsId);
    }
}