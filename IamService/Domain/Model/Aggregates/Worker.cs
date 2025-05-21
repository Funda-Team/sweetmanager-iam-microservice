using System;
using System.Collections.Generic;
using IamService.Domain.Model.Entities;

namespace IamService.Domain.Model.Aggregates;

public partial class Worker
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }

    public string? State { get; set; }

    public int? RolesId { get; set; }

    public int? HotelsId { get; set; }

    public virtual ICollection<AssignmentWorker> AssignmentWorkers { get; set; } = new List<AssignmentWorker>();

    public virtual Role? Roles { get; set; }
}
