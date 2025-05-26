using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Commands.Credential;

namespace IamService.Domain.Model.Entities.Credentials
{
    public class WorkerCredential
    {
        public int WorkersId { get; private set; }

        public string Code { get; private set; }

        public Worker Worker { get; } = null!;

        public WorkerCredential() { }

        public WorkerCredential(CreateUserCredentialCommand command)
        {
            WorkersId = command.UserId;
            Code = command.Code;
        }

        public WorkerCredential(int workersId, string code)
        {
            WorkersId = workersId;
            Code = code;
        }
    }
}
