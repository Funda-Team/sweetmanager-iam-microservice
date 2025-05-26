namespace IamService.Domain.Model.Commands.Authentication.User;

public record SignInCommand(string Email, string Password, int RolesId);