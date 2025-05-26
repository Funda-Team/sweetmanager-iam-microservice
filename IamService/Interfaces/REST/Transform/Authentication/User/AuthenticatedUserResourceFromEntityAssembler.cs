using IamService.Interfaces.REST.Resource.Authentication.User;

namespace IamService.Interfaces.REST.Transform.Authentication.User;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(dynamic entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    }
}