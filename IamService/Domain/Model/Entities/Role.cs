using System;
using System.Collections.Generic;
using IamService.Domain.Model.Aggregates;

namespace IamService.Domain.Model.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Owner> Owners { get; set; } = new List<Owner>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
