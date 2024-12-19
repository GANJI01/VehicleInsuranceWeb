using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABZVehicleLibrary.Models;

public partial class ABZVehicleDBContext : DbContext
{
    public ABZVehicleDBContext()
    {
    }

    public ABZVehicleDBContext(DbContextOptions<ABZVehicleDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=ABZVehicleDB; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D88B371D6B");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.RegNo).HasName("PK__Vehicle__2C6FF1E8562847D2");

            entity.ToTable("Vehicle");

            entity.Property(e => e.RegNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BodyType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ChassisNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EngineNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FuelType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LeasedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Make)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MfgYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Model)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OwnerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegAuthority)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RegDate).HasColumnType("datetime");
            entity.Property(e => e.Variant)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vehicle__OwnerId__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
