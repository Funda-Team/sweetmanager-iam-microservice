using System;
using System.Collections.Generic;
using IamService.Domain.Model.Entities.Roles;

namespace IamService.Domain.Model.Aggregates;

public partial class Owner
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

    public virtual Role? Roles { get; set; }

    public Owner()
    {

    }

    public Owner(int id, string username, string email, int rolesId,
        string name, string surname, int phone, int hotelsId ,string state)
    {
        Id = id;
        Username = username;
        Email = email;
        RolesId = rolesId;
        Name = name;
        Surname = surname;
        Phone = phone;
        HotelsId = hotelsId;
        State = state;
    }
}
