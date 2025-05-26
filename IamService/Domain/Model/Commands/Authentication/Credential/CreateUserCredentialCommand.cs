namespace IamService.Domain.Model.Commands.Credential;

public record CreateUserCredentialCommand(int UserId, string Code);