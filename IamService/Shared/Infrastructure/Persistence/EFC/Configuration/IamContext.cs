using System;
using System.Collections.Generic;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using IamService.Domain.Model.Aggregates;
using IamService.Domain.Model.Entities;
using IamService.Domain.Model.Entities.Roles;
using Microsoft.EntityFrameworkCore;

namespace IamService.Shared.Infrastructure.Persistence.EFC.Configuration;

public partial class IamContext : DbContext
{
    public IamContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    public IamContext(DbContextOptions<IamContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admins");

            entity.HasIndex(e => e.RolesId, "roles_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HotelsId).HasColumnName("hotels_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.RolesId).HasColumnName("roles_id");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("state");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Roles).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("admins_ibfk_1");
        });

        modelBuilder.Entity<AssignmentWorker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assignment_workers");

            entity.HasIndex(e => e.AdminsId, "admins_id");

            entity.HasIndex(e => e.WorkerAreasId, "worker_areas_id");

            entity.HasIndex(e => e.WorkersId, "workers_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminsId).HasColumnName("admins_id");
            entity.Property(e => e.FinalDate)
                .HasColumnType("datetime")
                .HasColumnName("final_date");
            entity.Property(e => e.HotelsId).HasColumnName("hotels_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("state");
            entity.Property(e => e.WorkerAreasId).HasColumnName("worker_areas_id");
            entity.Property(e => e.WorkersId).HasColumnName("workers_id");

            entity.HasOne(d => d.Admins).WithMany(p => p.AssignmentWorkers)
                .HasForeignKey(d => d.AdminsId)
                .HasConstraintName("assignment_workers_ibfk_3");

            entity.HasOne(d => d.WorkerAreas).WithMany(p => p.AssignmentWorkers)
                .HasForeignKey(d => d.WorkerAreasId)
                .HasConstraintName("assignment_workers_ibfk_1");

            entity.HasOne(d => d.Workers).WithMany(p => p.AssignmentWorkers)
                .HasForeignKey(d => d.WorkersId)
                .HasConstraintName("assignment_workers_ibfk_2");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("owners");

            entity.HasIndex(e => e.RolesId, "roles_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HotelsId).HasColumnName("hotels_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.RolesId).HasColumnName("roles_id");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("state");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Roles).WithMany(p => p.Owners)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("owners_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workers");

            entity.HasIndex(e => e.RolesId, "roles_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HotelsId).HasColumnName("hotels_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.RolesId).HasColumnName("roles_id");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("state");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Roles).WithMany(p => p.Workers)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("workers_ibfk_1");
        });

        modelBuilder.Entity<WorkerArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("worker_areas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
