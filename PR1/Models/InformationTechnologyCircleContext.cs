using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PR1.Models;

public partial class InformationTechnologyCircleContext : DbContext
{
    public InformationTechnologyCircleContext()
    {
    }

    public InformationTechnologyCircleContext(DbContextOptions<InformationTechnologyCircleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CoursesAndTeacher> CoursesAndTeachers { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HUAWEI\\SQLEXPRESS;Database=InformationTechnologyCircle; Integrated Security=True; TrustServerCertificate=False; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.IdAdmin);

            entity.ToTable("Administrator");

            entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");
            entity.Property(e => e.ConfirmationCode).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Administrators)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administrator_Role");

            entity.HasOne(d => d.UserInfoNavigation).WithMany(p => p.Administrators)
                .HasForeignKey(d => d.UserInfo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administrator_User1");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.IdCour);

            entity.Property(e => e.IdCour).HasColumnName("ID_Cour");
            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.Specialization).HasMaxLength(50);
        });

        modelBuilder.Entity<CoursesAndTeacher>(entity =>
        {
            entity.HasKey(e => e.IdCourAndTeach);

            entity.Property(e => e.IdCourAndTeach).HasColumnName("ID_CourAndTeach");
            entity.Property(e => e.CoursesId).HasColumnName("CoursesID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Courses).WithMany(p => p.CoursesAndTeachers)
                .HasForeignKey(d => d.CoursesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoursesAndTeachers_Courses");

            entity.HasOne(d => d.Teacher).WithMany(p => p.CoursesAndTeachers)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoursesAndTeachers_Teacher");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.IdEnroll);

            entity.Property(e => e.IdEnroll).HasColumnName("ID_Enroll");
            entity.Property(e => e.CoursesId).HasColumnName("CoursesID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Courses).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CoursesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Courses");

            entity.HasOne(d => d.User).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("ID_Role");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeach);

            entity.ToTable("Teacher");

            entity.Property(e => e.IdTeach).HasColumnName("ID_Teach");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Fname).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Surname).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fname).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Sex)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Surname).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
