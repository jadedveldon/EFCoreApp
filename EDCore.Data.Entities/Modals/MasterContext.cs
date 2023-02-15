using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EDCore.Data.Entities.Modals;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TL545;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("deptid");

            entity.ToTable("Department");

            entity.Property(e => e.DeptId).ValueGeneratedNever();
            entity.Property(e => e.Hod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HOD");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ID");

            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Deptid).HasColumnName("deptid");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Religion)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Deptid)
                .HasConstraintName("deptid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
