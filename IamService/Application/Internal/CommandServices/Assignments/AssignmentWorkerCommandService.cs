﻿using IamService.Domain.Model.Commands.Assignments;
using IamService.Domain.Model.Entities;
using IamService.Domain.Model.Repositories.Assignments;
using IamService.Domain.Services.Assignments;
using IamService.Shared.Domain.Repositories;

namespace IamService.Application.Internal.CommandServices.Assignments;

public class AssignmentWorkerCommandService(IAssignmentWorkerRepository assignmentWorkerRepository, 
    IUnitOfWork unitOfWork) : IAssignmentWorkerCommandService
{
    public async Task<bool> Handle(CreateAssignmentWorkerCommand command)
    {
        try
        {

            // Find an Active Assignment for the given Worker's DNI
            var verificationWorkerId = await assignmentWorkerRepository.FindByWorkerIdAsync(command.WorkersId);
            
            if (verificationWorkerId.Any())
                throw new Exception($"There's already an active assignment with the given worker id: {command.WorkersId}");

            if (string.IsNullOrEmpty(command.WorkersId.ToString()) || string.IsNullOrEmpty(command.AdminsId.ToString()))
                throw new Exception("No empty dnis.");
            
            if (command.WorkersId is 0 && command.AdminsId is not 0)
            {
                await assignmentWorkerRepository.AddAsync(new AssignmentWorker(command.WorkersAreasId,
                    null, command.AdminsId, command.StartDate, command.FinalDate, command.State));
            }
            else if(command.AdminsId is 0 && command.WorkersId is not 0)
            {
                await assignmentWorkerRepository.AddAsync(new AssignmentWorker(command.WorkersAreasId,
                    command.WorkersId, null, command.StartDate, command.FinalDate, command.State));
            }
            else
            {
                await assignmentWorkerRepository.AddAsync(new AssignmentWorker(command.WorkersAreasId,
                    command.WorkersId, command.AdminsId, command.StartDate, command.FinalDate, command.State));
            }
            
            await unitOfWork.CommitAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}