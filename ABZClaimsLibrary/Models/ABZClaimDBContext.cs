using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABZClaimsLibrary.Models;

public partial class ABZClaimDBContext : DbContext
{
    public ABZClaimDBContext()
    {
    }

    public ABZClaimDBContext(DbContextOptions<ABZClaimDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=ABZClaimDB; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.ClaimNo).HasName("PK__Claim__EF2E7A04D559B395");

            entity.ToTable("Claim");

            entity.Property(e => e.ClaimNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ClaimAmount).HasColumnType("money");
            entity.Property(e => e.ClaimDate).HasColumnType("datetime");
            entity.Property(e => e.ClaimStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IncidentDate).HasColumnType("datetime");
            entity.Property(e => e.IncidentDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IncidentLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PolicyNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SurveyDate).HasColumnType("datetime");
            entity.Property(e => e.SurveyDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SurveyorName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SurveyorPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.PolicyNoNavigation).WithMany(p => p.Claims)
                .HasForeignKey(d => d.PolicyNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Claim__PolicyNo__38996AB5");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.PolicyNo).HasName("PK__Policy__2E132197F3649786");

            entity.ToTable("Policy");

            entity.Property(e => e.PolicyNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
