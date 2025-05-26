using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Commands.Credential;

namespace IamService.Domain.Model.Entities.Credentials
{
    public class OwnerCredential
    {
        public int OwnersId { get; private set; }

        public string Code { get; private set; }

        public virtual Owner Owner { get; } = null!;

        public OwnerCredential() { }

        public OwnerCredential(CreateUserCredentialCommand command)
        {
            OwnersId = command.UserId;
            Code = command.Code;
        }

        public OwnerCredential(int ownersId, string code)
        {
            OwnersId = ownersId;
            Code = code;
        }
    }
}