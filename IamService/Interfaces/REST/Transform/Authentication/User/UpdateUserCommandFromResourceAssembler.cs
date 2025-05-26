using IamService.Domain.Model.Commands.Authentication.User;
using IamService.Interfaces.REST.Resource.Authentication.User;

namespace IamService.Interfaces.REST.Transform.Authentication.User;

public static class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource(UpdateUserResource resource)
    {
        return new UpdateUserCommand(resource.Id, resource.Attribute, resource.Value);
    }
}