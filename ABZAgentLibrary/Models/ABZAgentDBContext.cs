using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABZAgentLibrary.Models;

public partial class ABZAgentDBContext : DbContext
{
    public ABZAgentDBContext()
    {
    }

    public ABZAgentDBContext(DbContextOptions<ABZAgentDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=ABZAgentDB; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentID).HasName("PK__Agent__9AC3BFD1558E4C78");

            entity.ToTable("Agent");

            entity.Property(e => e.AgentID)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AgentEmail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AgentName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AgentPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LicenseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
