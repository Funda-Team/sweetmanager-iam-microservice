﻿using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace IamService.Domain.Model.Aggregates
{
    public partial class Admin : IEntityWithCreatedUpdatedDate
    {
        [Column("created_at")] public DateTimeOffset? CreatedDate { get; set; }

        [Column("updated_at")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}