namespace IamService.Interfaces.REST.Resource.Authentication.User;

public record SignInResource(string Email, string Password, int RolesId);