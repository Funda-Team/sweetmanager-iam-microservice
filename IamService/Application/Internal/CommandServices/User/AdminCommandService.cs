using IamService.Application.Internal.OutboundServices;
using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Commands.Authentication.User;
using IamService.Domain.Model.Exceptions;
using IamService.Domain.Model.Repositories.Credential;
using IamService.Domain.Repositories.Users;
using IamService.Domain.Services.Users;
using IamService.Shared.Domain.Repositories;

namespace IamService.Application.Internal.CommandServices.User;

public class AdminCommandService(IUnitOfWork unitOfWork, IAdminRepository adminRepository, 
    IAdminCredentialRepository adminCredentialRepository, 
    IHashingService hashingService, 
    ITokenService tokenService) : IAdminCommandService
{
    public async Task<bool> Handle(SignUpUserCommand command)
    {
        try
        {
            if (await adminRepository.FindByEmail(command.Email) is not null)
                throw new EmailAlreadyExistException();
            
            // Add Admin

            await adminRepository.AddAsync(new Admin(command.Id, command.Username, command.Email, 2, command.Name,
                command.Surname, command.Phone, command.HotelsId, command.State));

            await unitOfWork.CommitAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while creating the user: {ex.Message}");
        }
    }

    public async Task<bool> Handle(UpdateUserCommand command)
    {
        try
        {
            if (await adminRepository.FindById(command.Id) is null)
                throw new Exception($"There's no admin with the given id: {command.Id}");
            
            var result = false;
            
            if (command.Change.ToUpper() == "PHONE")
            {
                await adminRepository.ExecuteUpdateAdminPhoneAsync(Convert.ToInt32(command.Value), command.Id);

                await unitOfWork.CommitAsync();

                result = true;
            }
            else
            {
                await adminRepository.ExecuteUpdateAdminEmailAsync(command.Value, command.Id);

                await unitOfWork.CommitAsync();

                result = true;
            }

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while updating the user: {ex.Message}");
        }
    }

    public async Task<dynamic?> Handle(SignInCommand command)
    {
        try
        {
            var user = await adminRepository.FindByEmail(command.Email);

            if (user is null)
                throw new EmailDoesntExistException();

            var userCredential = await adminCredentialRepository.FindByIdAsync(user.Id);

            if (!hashingService.VerifyHash(command.Password, userCredential!.Code[..24], userCredential!.Code[24..]))
                throw new InvalidPasswordException();

            var token = tokenService.GenerateToken(new
            {
                Id = user.Id,
                PasswordHash = userCredential.Code,
                Role = "ROLE_ADMIN",
                Hotel = user.HotelsId 
            });

            return new
            {
                User = user,
                Token = token
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}