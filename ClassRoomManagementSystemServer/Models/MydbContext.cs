using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomManagementSystemServer.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<TimeSlot> TimeSlots { get; set; }
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
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PRIMARY");

            entity.ToTable("classroom");

            entity.HasIndex(e => e.DepartmentDepartmentName, "fk_Classroom_Department1_idx");

            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.BlackoutHours)
                .HasColumnType("time")
                .HasColumnName("blackout_hours");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.DepartmentDepartmentName)
                .HasMaxLength(45)
                .HasColumnName("Department_department_name");
            entity.Property(e => e.RoomNum).HasColumnName("room_num");

            entity.HasOne(d => d.DepartmentDepartmentNameNavigation).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.DepartmentDepartmentName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Classroom_Department1");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseTitle).HasName("PRIMARY");

            entity.ToTable("course");

            entity.HasIndex(e => e.DepartmentDepartmentName, "fk_Course_Department1_idx");

            entity.Property(e => e.CourseTitle)
                .HasMaxLength(10)
                .HasColumnName("course_title");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.DepartmentDepartmentName)
                .HasMaxLength(45)
                .HasColumnName("Department_department_name");

            entity.HasOne(d => d.DepartmentDepartmentNameNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentDepartmentName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Course_Department1");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentName).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(45)
                .HasColumnName("department_name");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(45)
                .HasColumnName("building_name");
            entity.Property(e => e.NumClassroom).HasColumnName("num_classroom");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.HasIndex(e => e.ClassroomClassroomId, "fk_Equipment_Classroom1_idx");

            entity.HasIndex(e => e.CourseCourseTitle, "fk_Equipment_Course1_idx");

            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.ClassroomClassroomId).HasColumnName("Classroom_classroom_id");
            entity.Property(e => e.CourseCourseTitle)
                .HasMaxLength(10)
                .HasColumnName("Course_course_title");
            entity.Property(e => e.EquipmentType)
                .HasMaxLength(45)
                .HasColumnName("equipment_type");

            entity.HasOne(d => d.ClassroomClassroom).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.ClassroomClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Equipment_Classroom1");

            entity.HasOne(d => d.CourseCourseTitleNavigation).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.CourseCourseTitle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Equipment_Course1");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.ToTable("request");

            entity.HasIndex(e => e.ClassroomClassroomId, "fk_Request_Classroom1_idx");

            entity.HasIndex(e => e.DepartmentDepartmentName, "fk_Request_Department_idx");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.ClassroomClassroomId).HasColumnName("Classroom_classroom_id");
            entity.Property(e => e.DepartmentDepartmentName)
                .HasMaxLength(45)
                .HasColumnName("Department_department_name");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.HasOne(d => d.ClassroomClassroom).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClassroomClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Request_Classroom1");

            entity.HasOne(d => d.DepartmentDepartmentNameNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.DepartmentDepartmentName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Request_Department");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => new { e.SectionId, e.CourseTitle, e.Semester, e.Year, e.CourseCourseTitle })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

            entity.ToTable("section");

            entity.HasIndex(e => e.ClassroomClassroomId, "fk_Section_Classroom1_idx");

            entity.HasIndex(e => e.CourseCourseTitle, "fk_Section_Course1_idx");

            entity.HasIndex(e => e.TimeSlotTimeSlotId, "fk_Section_Time_Slot1_idx");

            entity.Property(e => e.SectionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("section_id");
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(45)
                .HasColumnName("course_title");
            entity.Property(e => e.Semester)
                .HasMaxLength(45)
                .HasColumnName("semester");
            entity.Property(e => e.Year)
                .HasMaxLength(45)
                .HasColumnName("year");
            entity.Property(e => e.CourseCourseTitle)
                .HasMaxLength(10)
                .HasColumnName("Course_course_title");
            entity.Property(e => e.ClassroomClassroomId).HasColumnName("Classroom_classroom_id");
            entity.Property(e => e.TimeSlotTimeSlotId).HasColumnName("Time_Slot_time_slot_id");

            entity.HasOne(d => d.ClassroomClassroom).WithMany(p => p.Sections)
                .HasForeignKey(d => d.ClassroomClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Section_Classroom1");

            entity.HasOne(d => d.CourseCourseTitleNavigation).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CourseCourseTitle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Section_Course1");

            entity.HasOne(d => d.TimeSlotTimeSlot).WithMany(p => p.Sections)
                .HasForeignKey(d => d.TimeSlotTimeSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Section_Time_Slot1");
        });

        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.HasKey(e => e.TimeSlotId).HasName("PRIMARY");

            entity.ToTable("time_slot");

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
