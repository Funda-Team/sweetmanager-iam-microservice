using IamService.Domain.Model.Commands.Role;
using IamService.Interfaces.REST.Resource.Authentication.Role;

namespace IamService.Interfaces.REST.Transform.Authentication.Role;

public static class CreateWorkAreaCommandFromResourceAssembler
{
    public static CreateWorkAreaCommand ToCommandFromResource(CreateWorkAreaResource resource)
    {
        return new CreateWorkAreaCommand(resource.Name, resource.HotelId);
    }
}