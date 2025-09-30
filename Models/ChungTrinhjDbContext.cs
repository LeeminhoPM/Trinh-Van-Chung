using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChungTrinhj.Models;

public partial class ChungTrinhjDbContext : DbContext
{
    public ChungTrinhjDbContext()
    {
    }

    public ChungTrinhjDbContext(DbContextOptions<ChungTrinhjDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-5PUN7V05;Database=ChungTrinhjDB;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasColumnName("phone");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
