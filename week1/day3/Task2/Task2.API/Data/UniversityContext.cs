using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Task2.API.Data.Models;

namespace Task2.API.Data;

public partial class UniversityContext : DbContext
{
    public UniversityContext()
    {
    }

    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Courser> Coursers { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Syllabus> Syllabi { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MVOD94J\\SQLEXPRESS;Database=University;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__32499E77F66859D5");

            entity.Property(e => e.AssignmentTitle)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");

            entity.HasOne(d => d.Course).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignments_Coursers");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFCA5E277882");

            entity.Property(e => e.CommentContent).HasColumnType("text");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Assignment).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__Assign__412EB0B6");

            entity.HasOne(d => d.CreatedeByUser).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CreatedeByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__Create__4222D4EF");
        });

        modelBuilder.Entity<Courser>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Coursers__C92D71877F3C3C3A");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StarteDate).HasColumnType("datetime");

            entity.HasOne(d => d.Syllabus).WithMany(p => p.Coursers)
                .HasForeignKey(d => d.SyllabusId)
                .HasConstraintName("FK_Coursers_Syllabus");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Coursers)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_Coursers_Users");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A5783E53AE4");

            entity.Property(e => e.Grade1).HasColumnName("Grade");

            entity.HasOne(d => d.Assignment).WithMany(p => p.Grades)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Assignments");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Users");
        });

        modelBuilder.Entity<Syllabus>(entity =>
        {
            entity.HasKey(e => e.SyllabusId).HasName("PK__Syllabus__9B8016A6BC42B6D4");

            entity.ToTable("Syllabus");

            entity.Property(e => e.Description).HasColumnType("text");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.EmailAddress, "EmailAddress_Users_unique").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
