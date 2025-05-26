using IamService.Application.Internal.OutboundServices;
using IamService.Domain.Model.Commands.Credential;
using IamService.Domain.Model.Entities.Credentials;
using IamService.Domain.Model.Repositories.Credential;
using IamService.Domain.Services.Credential.Admin;
using IamService.Shared.Domain.Repositories;

namespace IamService.Application.Internal.CommandServices.Credential;

public class AdminCredentialCommandService(IUnitOfWork unitOfWork,
    IHashingService hashingService, IAdminCredentialRepository adminCredentialRepository): IAdminCredentialCommandService
{
    public async Task<bool> Handle(CreateUserCredentialCommand command)
    {
        try
        {
            var salt = hashingService.CreateSalt();

            var code = hashingService.HashCode(command.Code, salt);

            await adminCredentialRepository.AddAsync(new AdminCredential(command.UserId, string.Concat(salt, code)));

            await unitOfWork.CommitAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}