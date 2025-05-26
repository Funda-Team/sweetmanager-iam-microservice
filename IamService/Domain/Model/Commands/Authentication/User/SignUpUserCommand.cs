namespace IamService.Domain.Model.Commands.Authentication.User;

public record SignUpUserCommand(int Id, string Username, string Name, string Surname, string Email, int Phone, string State, string Password, int HotelsId);