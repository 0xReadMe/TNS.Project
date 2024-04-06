using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TNS.Database;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=deadaddead");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pk");

            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");
            entity.Property(e => e.PhotoId)
                .HasMaxLength(20)
                .HasColumnName("photo_id");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
        });

        modelBuilder.Entity<EmployeePosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_position_pk");

            entity.ToTable("employee_position");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EmployeePosition1)
                .HasMaxLength(50)
                .HasColumnName("employee_position");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pk");

            entity.ToTable("events");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(50)
                .HasColumnName("event_description");
            entity.Property(e => e.EventTime)
                .HasMaxLength(5)
                .HasColumnName("event_time");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subscribers_pk");

            entity.ToTable("subscribers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(50)
                .HasColumnName("contract_number");
            entity.Property(e => e.ContractType)
                .HasMaxLength(5)
                .HasColumnName("contract_type");
            entity.Property(e => e.DateOfContractConclusion).HasColumnName("date_of_contract_conclusion");
            entity.Property(e => e.DateOfIssueOfPassport).HasColumnName("date_of_issue_of_passport");
            entity.Property(e => e.DateOfTerminationOfTheContract)
                .HasMaxLength(10)
                .HasColumnName("date_of_termination_of_the_contract");
            entity.Property(e => e.DivisionCode)
                .HasMaxLength(12)
                .HasColumnName("division_code");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(64)
                .HasColumnName("issued_by");
            entity.Property(e => e.PassportNumber).HasColumnName("passport_number");
            entity.Property(e => e.PassportSeries).HasColumnName("passport_series");
            entity.Property(e => e.PersonalBill).HasColumnName("personal_bill");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.ReasonForTerminationOfContract)
                .HasMaxLength(20)
                .HasColumnName("reason_for_termination_of_contract");
            entity.Property(e => e.ResidenceAddress)
                .HasMaxLength(128)
                .HasColumnName("residence_address");
            entity.Property(e => e.ResidentialAddress)
                .HasMaxLength(20)
                .HasColumnName("residential_address");
            entity.Property(e => e.SerialNumberOfEquipment)
                .HasMaxLength(20)
                .HasColumnName("serial_number_of_equipment");
            entity.Property(e => e.Services)
                .HasMaxLength(20)
                .HasColumnName("services");
            entity.Property(e => e.SubscriberNumber)
                .HasMaxLength(12)
                .HasColumnName("subscriber_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
