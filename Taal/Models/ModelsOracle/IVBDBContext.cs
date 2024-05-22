using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Taal.Models.ModelsOracle;

public partial class IVBDbContext : DbContext
{
    public IVBDbContext()
    {
    }

    public IVBDbContext(DbContextOptions<IVBDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Taal> Taals { get; set; }

    public virtual DbSet<Vertaling> Vertalings { get; set; }

    public virtual DbSet<Vertalinglink> Vertalinglinks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=IVBUSER;Password=IVB;Data Source=localhost:1521/IVB;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("IVBUSER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Taal>(entity =>
        {
            entity.HasKey(e => e.Seqlang);

            entity.ToTable("TAAL");

            entity.Property(e => e.Seqlang)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("SEQLANG");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("CREDAT");
            entity.Property(e => e.Creusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CREUSR");
            entity.Property(e => e.Seqtrans)
                .HasPrecision(8)
                .HasColumnName("SEQTRANS");
            entity.Property(e => e.Upddat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("UPDDAT");
            entity.Property(e => e.Updusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDUSR");

            entity.HasOne(d => d.Vertaling).WithMany(p => p.Taals)
                .HasForeignKey(d => new { d.Seqtrans, d.Seqlang })
                .HasConstraintName("FK_TAAL_VERTALIN");
        });

        modelBuilder.Entity<Vertaling>(entity =>
        {
            entity.HasKey(e => new { e.Seqtrans, e.Seqlang }).HasName("PK_TRANSLATION");

            entity.ToTable("VERTALING");

            entity.Property(e => e.Seqtrans)
                .HasPrecision(8)
                .HasColumnName("SEQTRANS");
            entity.Property(e => e.Seqlang)
                .HasPrecision(8)
                .HasColumnName("SEQLANG");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("CREDAT");
            entity.Property(e => e.Creusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CREUSR");
            entity.Property(e => e.Translat)
                .IsUnicode(false)
                .HasColumnName("TRANSLAT");
            entity.Property(e => e.Upddat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("UPDDAT");
            entity.Property(e => e.Updusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDUSR");

            entity.HasOne(d => d.SeqtransNavigation).WithMany(p => p.Vertalings)
                .HasForeignKey(d => d.Seqtrans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VERTALIN_VERTALIN");
        });

        modelBuilder.Entity<Vertalinglink>(entity =>
        {
            entity.HasKey(e => e.Seqtrans).HasName("PK_TRANSLATIONLINK");

            entity.ToTable("VERTALINGLINK");

            entity.Property(e => e.Seqtrans)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("SEQTRANS");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("CREDAT");
            entity.Property(e => e.Creusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CREUSR");
            entity.Property(e => e.Upddat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("UPDDAT");
            entity.Property(e => e.Updusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDUSR");
        });
        modelBuilder.HasSequence("ANALYTICSSEQ");
        modelBuilder.HasSequence("BELBEEFSEQ");
        modelBuilder.HasSequence("CERTIFICAATSEQ");
        modelBuilder.HasSequence("CW3C_RUBO_FILENR");
        modelBuilder.HasSequence("CW3C_RUBO_WEEGNR");
        modelBuilder.HasSequence("CW3C_VAPO_WEEGNR");
        modelBuilder.HasSequence("DBOBJECTID_SEQUENCE").IncrementsBy(50);
        modelBuilder.HasSequence("DOCUMENTSEQ");
        modelBuilder.HasSequence("EMAILCONFIRMATIONSEQ");
        modelBuilder.HasSequence("INVOICEBATCHSEQ");
        modelBuilder.HasSequence("IVBSEQ");
        modelBuilder.HasSequence("IVBSRVFLDSEQ");
        modelBuilder.HasSequence("IVBSRVUSRSEQ");
        modelBuilder.HasSequence("LOGSEQ");
        modelBuilder.HasSequence("LOTDASHBOARDSEQ");
        modelBuilder.HasSequence("LOTSEQ");
        modelBuilder.HasSequence("MAILQUEUEITEMSEQ");
        modelBuilder.HasSequence("MERITUSSEQ");
        modelBuilder.HasSequence("NOTIFICATIONCONFIRMATIONSEQ");
        modelBuilder.HasSequence("REPORTSEQ");
        modelBuilder.HasSequence("RUNDSEQ");
        modelBuilder.HasSequence("SEQ_ATTACHMENT");
        modelBuilder.HasSequence("SEQ_LOTEN");
        modelBuilder.HasSequence("SLACHTRAPPORTENSEQ");
        modelBuilder.HasSequence("VARKSEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
