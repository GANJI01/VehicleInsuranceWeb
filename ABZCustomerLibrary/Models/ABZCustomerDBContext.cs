using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABZCustomerLibrary.Models;

public partial class ABZCustomerDBContext : DbContext
{
    public ABZCustomerDBContext()
    {
    }

    public ABZCustomerDBContext(DbContextOptions<ABZCustomerDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=ABZCustomerDB; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerID).HasName("PK__Customer__A4AE64B8DA84589E");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
