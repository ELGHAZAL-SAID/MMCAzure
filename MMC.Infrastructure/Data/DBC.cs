using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MMC.Domain.Entities;

namespace MMC.Infrastructure.Data;

public partial class DBC : DbContext
{
    public DBC()
    {
    }

    public DBC(DbContextOptions<DBC> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PresentationSupport> PresentationSupports { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=portal.snifly.com;Initial Catalog=MMC_Support;Persist Security Info=True;User ID=jobInTechUserMMC;Password=Er@1Q@23sz;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partners__3214EC27ABA42089");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .HasColumnName("LogoURL");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<PresentationSupport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Presenta__3214EC27305A3854");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.SupportType).HasMaxLength(100);
            entity.Property(e => e.SupportUrl)
                .HasMaxLength(255)
                .HasColumnName("SupportURL");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sponsors__3214EC27EC5EC423");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .HasColumnName("LogoURL");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
