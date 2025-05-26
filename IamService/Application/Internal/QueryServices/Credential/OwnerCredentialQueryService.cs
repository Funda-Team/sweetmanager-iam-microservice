using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Model.Queries;
using IamService.Domain.Repositories.Credential;
using IamService.Domain.Services.Credential.Owner;

namespace IamService.Application.Internal.QueryServices.Credential;

public class OwnerCredentialQueryService(IOwnerCredentialRepository ownerCredentialRepository) : IOwnerCredentialQueryService
{
    public async Task<OwnerCredential?> Handle(GetUserCredentialByIdQuery query)
        => await ownerCredentialRepository.FindByOwnersIdAsync(query.UserId);
}