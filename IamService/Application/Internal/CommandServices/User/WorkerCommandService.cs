using IamService.Application.Internal.OutboundServices;
using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Commands.Authentication.User;
using IamService.Domain.Model.Exceptions;
using IamService.Domain.Repositories.Credential;
using IamService.Domain.Repositories.Users;
using IamService.Domain.Services.Users.Worker;
using IamService.Shared.Domain.Repositories;

namespace IamService.Application.Internal.CommandServices.User;

public class WorkerCommandService(IUnitOfWork unitOfWork, 
    IWorkerRepository workerRepository, 
    IHashingService hashingService,
    IWorkerCredentialRepository workerCredentialRepository,
    ITokenService tokenService
    ) : IWorkerCommandService
{
    public async Task<bool> Handle(SignUpUserCommand command)
    {
        try
        {
            if (await workerRepository.FindByEmail(command.Email) is not null)
                throw new EmailAlreadyExistException();
            
            // Add Worker

            await workerRepository.AddAsync(new Worker(command.Id, command.Username, command.Email, 3, command.Name,
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
            var result = false;

            if (await workerRepository.FindById(command.Id) is null)
                throw new Exception($"There's no worker with the given id: {command.Id}");
            
            if (command.Change.ToUpper() == "PHONE")
            {
                await workerRepository.ExecuteUpdateWorkerPhoneAsync(Convert.ToInt32(command.Value), command.Id);

                await unitOfWork.CommitAsync();

                result = true;
            }
            else
            {
                await workerRepository.ExecuteUpdateWorkerEmailAsync(command.Value, command.Id);

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
            var user = await workerRepository.FindByEmail(command.Email);

            if (user is null)
                throw new EmailDoesntExistException();

            var userCredential = await workerCredentialRepository.FindByWorkersIdAsync(user.Id);

            if (!hashingService.VerifyHash(command.Password, userCredential!.Code[..24], userCredential!.Code[24..]))
                throw new InvalidPasswordException();

            var token = tokenService.GenerateToken(new
            {
                Id = user.Id,
                PasswordHash = userCredential.Code,
                Role = "ROLE_WORKER",
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