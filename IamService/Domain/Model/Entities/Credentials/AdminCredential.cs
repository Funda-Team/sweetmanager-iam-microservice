using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Commands.Credential;

namespace IamService.Domain.Model.Entities.Credentials
{
    public class AdminCredential
    {
        public int AdminsId { get; private set; }

        public string Code { get; private set; }

        public Admin Admin { get; } = null!;

        public AdminCredential() { }

        public AdminCredential(CreateUserCredentialCommand command)
        {
            AdminsId = command.UserId;
            Code = command.Code;
        }

        public AdminCredential(int adminsId, string code)
        {
            AdminsId = adminsId;
            Code = code;
        }
    }
}