using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Model.Queries;

namespace IamService.Domain.Services.Credential.Owner;

public interface IOwnerCredentialQueryService
{
    Task<OwnerCredential?> Handle(GetUserCredentialByIdQuery query);
    
}