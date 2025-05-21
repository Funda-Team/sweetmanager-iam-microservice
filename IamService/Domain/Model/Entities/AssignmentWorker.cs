using System;
using System.Collections.Generic;
using IamService.Domain.Model.Aggregates;

namespace IamService.Domain.Model.Entities;

public partial class AssignmentWorker
{
    public int Id { get; set; }

    public int? WorkerAreasId { get; set; }

    public int? WorkersId { get; set; }

    public int? AdminsId { get; set; }

    public int? HotelsId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinalDate { get; set; }

    public string? State { get; set; }

    public virtual Admin? Admins { get; set; }

    public virtual WorkerArea? WorkerAreas { get; set; }

    public virtual Worker? Workers { get; set; }
}
