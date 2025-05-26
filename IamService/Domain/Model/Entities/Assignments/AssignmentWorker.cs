using System;
using System.Collections.Generic;
using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Commands.Assignments;
using IamService.Domain.Model.Entities.Roles;

namespace IamService.Domain.Model.Entities;

public partial class AssignmentWorker
{
    public int Id { get; set; }

    public int? WorkerAreasId { get; set; }

    public int? WorkersId { get; set; }

    public int? AdminsId { get; set; }

    public int? HotelsId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime FinalDate { get; set; }

    public string? State { get; set; }

    public virtual Admin? Admins { get; set; }

    public virtual WorkerArea? WorkerAreas { get; set; }

    public virtual Worker? Workers { get; set; }

    public AssignmentWorker() { }

    public AssignmentWorker(int workersAreasId, int? workersId, int? adminsId, DateTime startDate, DateTime finalDate, string state)
    {
        WorkerAreasId = workersAreasId;
        WorkersId = workersId;
        AdminsId = adminsId;
        StartDate = startDate;
        FinalDate = finalDate;
        State = state.ToUpper();
    }

    public AssignmentWorker(CreateAssignmentWorkerCommand command)
    {
        WorkerAreasId = command.WorkersAreasId;
        WorkersId = command.WorkersId;
        AdminsId = command.AdminsId;
        StartDate = command.StartDate;
        FinalDate = command.FinalDate;
        State = command.State.ToUpper();
    }
}
