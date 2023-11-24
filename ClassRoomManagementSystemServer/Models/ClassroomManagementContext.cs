using System;
using System.Collections.Generic;
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

    public virtual DbSet<TimeSlot> TimeSlots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=ClassroomManagement;uid=root;pwd=Ghita1123581321$", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingName).HasName("PRIMARY");

            entity.ToTable("Building");

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
                .HasConstraintName("Classroom_FK");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("Course");

            entity.HasIndex(e => e.DepartmentName, "Course_FK");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .HasColumnName("department_name");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.DepartmentNameNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentName)
                .HasConstraintName("Course_FK");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentName).HasName("PRIMARY");

            entity.ToTable("Department");

            entity.HasIndex(e => e.BuildingName, "Department_FK");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .HasColumnName("department_name");
            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(100)
                .HasColumnName("building_name");

            entity.HasOne(d => d.BuildingNameNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.BuildingName)
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

            entity.HasIndex(e => e.DepartmentName, "Requests_FK_1");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .HasColumnName("department_name");
            entity.Property(e => e.Descritption).HasColumnType("text");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Requests_FK");

            entity.HasOne(d => d.DepartmentNameNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.DepartmentName)
                .HasConstraintName("Requests_FK_1");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => new { e.SectionId, e.CourseId, e.Semester, e.Year })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("Section");

            entity.HasIndex(e => e.CourseId, "Section_FK");

            entity.HasIndex(e => e.ClassroomId, "Section_FK_1");

            entity.HasIndex(e => e.TimeSlotId, "Section_FK_2");

            entity.Property(e => e.SectionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("section_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Semester)
                .HasMaxLength(100)
                .HasColumnName("semester");
            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.TimeSlotId).HasColumnName("time_slot_id");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Sections)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Section_FK_1");

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Section_FK");

            entity.HasOne(d => d.TimeSlot).WithMany(p => p.Sections)
                .HasForeignKey(d => d.TimeSlotId)
                .HasConstraintName("Section_FK_2");
        });

        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.HasKey(e => e.TimeSlotId).HasName("PRIMARY");

            entity.ToTable("Time_Slot");

            entity.Property(e => e.TimeSlotId).HasColumnName("time_slot_id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasColumnName("start_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
