namespace IamService.Interfaces.REST.Resource.Assignments;

public record CreateAssignmentWorkerResource(int WorkerAreasId, int WorkersId, int AdminsId,
    string StartDate, string FinalDate, string State);