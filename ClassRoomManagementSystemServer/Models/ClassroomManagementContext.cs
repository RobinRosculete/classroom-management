using System;
using System.Collections.Generic;
using ClassRoomManagementSystemServer.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomManagementSystemServer.Models;

public partial class ClassroomManagementContext : DbContext
{
    public ClassroomManagementContext()
    {
    }

    public ClassroomManagementContext(DbContextOptions<ClassroomManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SectionTimeSlot> SectionTimeSlots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json");
        IConfiguration configuration = builder.Build();
        // Handeling Null refrence error

        string? connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string is null.");
        var serverVersion = Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql");

        optionsBuilder.UseMySql(connectionString, serverVersion);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingName).HasName("PRIMARY");

            entity.ToTable("Building");

            entity.HasIndex(e => e.BuildingName, "building_name_UNIQUE").IsUnique();

            entity.Property(e => e.BuildingName)
                .HasMaxLength(100)
                .HasColumnName("building_name");
            entity.Property(e => e.NumberClassrooms).HasColumnName("number_classrooms");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PRIMARY");

            entity.ToTable("Classroom");

            entity.HasIndex(e => e.BuildingName, "Classroom_FK");

            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.BackoutHours)
                .HasColumnType("time")
                .HasColumnName("backout_hours");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(100)
                .HasColumnName("building_name");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");

            entity.HasOne(d => d.BuildingNameNavigation).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.BuildingName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Classroom_FK");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("Course");

            entity.HasIndex(e => e.DepartmentId, "Course_FK");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("Course_FK");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("Department");

            entity.HasIndex(e => e.BuildingName, "building_name_UNIQUE").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(100)
                .HasColumnName("building_name");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .HasColumnName("department_name");

            entity.HasOne(d => d.BuildingNameNavigation).WithOne(p => p.Department)
                .HasForeignKey<Department>(d => d.BuildingName)
                .HasConstraintName("Department_FK");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PRIMARY");

            entity.HasIndex(e => e.ClassroomId, "Equipment_FK");

            entity.HasIndex(e => e.CourseId, "Equipment_FK_1");

            entity.Property(e => e.EquipmentId)
                .ValueGeneratedNever()
                .HasColumnName("equipment_id");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.EquipmentType)
                .HasMaxLength(100)
                .HasColumnName("equipment_type");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Equipment_FK");

            entity.HasOne(d => d.Course).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Equipment_FK_1");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.HasIndex(e => e.ClassroomId, "Requests_FK");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.Descritption).HasColumnType("text");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Requests_FK");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => new { e.SectionId, e.CourseId, e.Semester, e.Year })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("Section");

            entity.HasIndex(e => e.CourseId, "Section_FK");

            entity.HasIndex(e => e.ClassroomId, "Section_FK_1");

            entity.Property(e => e.SectionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("section_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Semester)
                .HasMaxLength(100)
                .HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Sections)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Section_FK_1");

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Section_FK");
        });

        modelBuilder.Entity<SectionTimeSlot>(entity =>
        {
            entity.HasKey(e => e.SectionTimeSlotId).HasName("PRIMARY");

            entity.ToTable("Section_Time_Slot");

            entity.HasIndex(e => new { e.SectionId, e.CourseId, e.Semester, e.Year }, "Section_Time_Slot_FK");

            entity.Property(e => e.SectionTimeSlotId).HasColumnName("section_time_slot_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasColumnName("end_time");
            entity.Property(e => e.SectionId).HasColumnName("section_id");
            entity.Property(e => e.Semester)
                .HasMaxLength(100)
                .HasColumnName("semester");
            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasColumnName("start_time");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionTimeSlots)
                .HasForeignKey(d => new { d.SectionId, d.CourseId, d.Semester, d.Year })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Section_Time_Slot_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
