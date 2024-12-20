using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABZProposalLibrary.Models;

public partial class ABZProposalDBContext : DbContext
{
    public ABZProposalDBContext()
    {
    }

    public ABZProposalDBContext(DbContextOptions<ABZProposalDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Proposal> Proposals { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=ABZProposalDB; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentID).HasName("PK__Agent__9AC3BFD19698DB6B");

            entity.ToTable("Agent");

            entity.Property(e => e.AgentID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerID).HasName("PK__Customer__A4AE64B8CB5C57BC");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductID).HasName("PK__Product__B40CC6EDC39A7A3B");

            entity.ToTable("Product");

            entity.Property(e => e.ProductID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.HasKey(e => e.ProposalNo).HasName("PK__Proposal__6F39E10019679DFD");

            entity.ToTable("Proposal");

            entity.Property(e => e.ProposalNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AgentID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BasicAmount).HasColumnType("money");
            entity.Property(e => e.CustomerID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IDV).HasColumnType("money");
            entity.Property(e => e.ProductID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalAmount).HasColumnType("money");

            entity.HasOne(d => d.Agent).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.AgentID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proposal__AgentI__412EB0B6");

            entity.HasOne(d => d.Customer).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proposal__Custom__403A8C7D");

            entity.HasOne(d => d.Product).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proposal__Produc__3F466844");

            entity.HasOne(d => d.RegNoNavigation).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.RegNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proposal__RegNo__3E52440B");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.RegNO).HasName("PK__Vehicle__2C6FF1C8504E8C5B");

            entity.ToTable("Vehicle");

            entity.Property(e => e.RegNO)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
