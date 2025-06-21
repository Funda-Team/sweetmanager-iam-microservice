using IamService.Domain.Model.Aggregates;

namespace IamService.Interfaces.ACL
{
    public interface IIamContextFacade
    {
        Task<Admin?> FetchAdminByUserId(int id);

        Task<Owner?> FetchOwnerByUserId(int id);

        Task<Worker?> FetchWorkerByUserId(int id);
    }
}
