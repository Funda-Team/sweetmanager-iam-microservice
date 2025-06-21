using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Queries;
using IamService.Domain.Services.Users.Admin;
using IamService.Domain.Services.Users.Owner;
using IamService.Domain.Services.Users.Worker;

namespace IamService.Interfaces.ACL.Services
{
    public class IamContextFacade(IAdminQueryService adminQueryService, IOwnerQueryService ownerQueryService,
        IWorkerQueryService workerQueryService) : IIamContextFacade
    {
        public async Task<Admin?> FetchAdminByUserId(int id)
            => await adminQueryService.Handle(new GetUserByIdQuery(id));

        public async Task<Owner?> FetchOwnerByUserId(int id)
            => await ownerQueryService.Handle(new GetUserByIdQuery(id));

        public async Task<Worker?> FetchWorkerByUserId(int id)
            => await workerQueryService.Handle(new GetUserByIdQuery(id));
    }
}
