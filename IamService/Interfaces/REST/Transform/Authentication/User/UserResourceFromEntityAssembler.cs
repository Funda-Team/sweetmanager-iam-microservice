using IamService.Interfaces.REST.Resource.Authentication.User;

namespace IamService.Interfaces.REST.Transform.Authentication.User;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(dynamic user)
    {
        return new UserResource(user.Id, user.RolesId, user.Username, user.Name, user.Surname, user.Email, user.Phone,
            user.State);
    }
}