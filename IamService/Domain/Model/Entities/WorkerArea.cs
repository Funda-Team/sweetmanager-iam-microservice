using System;
using System.Collections.Generic;

namespace IamService.Domain.Model.Entities;

public partial class WorkerArea
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? HotelId { get; set; }

    public virtual ICollection<AssignmentWorker> AssignmentWorkers { get; set; } = new List<AssignmentWorker>();
}
