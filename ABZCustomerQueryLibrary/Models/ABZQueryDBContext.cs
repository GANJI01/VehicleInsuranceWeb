using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABZCustomerQueryLibrary.Models;

public partial class ABZQueryDBContext : DbContext
{
    public ABZQueryDBContext()
    {
    }

    public ABZQueryDBContext(DbContextOptions<ABZQueryDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerQuery> CustomerQueries { get; set; }

    public virtual DbSet<QueryResponse> QueryResponses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            // => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=ABZQueryDB; integrated security=true");
            => optionsBuilder.UseSqlServer("data source=sqlsvrchana.database.windows.net; database=ABZCustomerQuery-chana; user id=hana; password=Welcome@1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentID).HasName("PK__Agent__9AC3BFD1C9F08AC3");

            entity.ToTable("Agent");

            entity.Property(e => e.AgentID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerID).HasName("PK__Customer__A4AE64B82CA7E801");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<CustomerQuery>(entity =>
        {
            entity.HasKey(e => e.QueryID).HasName("PK__Customer__5967F7FBDC5A748B");

            entity.ToTable("CustomerQuery");

            entity.Property(e => e.QueryID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CustomerID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.QueryDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerQueries)
                .HasForeignKey(d => d.CustomerID)
                .HasConstraintName("FK__CustomerQ__Custo__3C69FB99");
        });

        modelBuilder.Entity<QueryResponse>(entity =>
        {
            entity.HasKey(e => new { e.QueryID, e.SrNo }).HasName("PK__QueryRes__855DBAC100A42678");

            entity.ToTable("QueryResponse");

            entity.Property(e => e.QueryID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SrNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AgentID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ResponseDate).HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.QueryResponses)
                .HasForeignKey(d => d.AgentID)
                .HasConstraintName("FK__QueryResp__Agent__3E52440B");

            entity.HasOne(d => d.Query).WithMany(p => p.QueryResponses)
                .HasForeignKey(d => d.QueryID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QueryResp__Query__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
