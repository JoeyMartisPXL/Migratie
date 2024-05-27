using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;

public partial class IVBDBContext : DbContext
{
    public IVBDBContext()
    {
    }

    public IVBDBContext(DbContextOptions<IVBDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonnement> Abonnements { get; set; }

    public virtual DbSet<VeehouderAbonnement> VeehouderAbonnements { get; set; }

    public virtual DbSet<Verzendingswijze> Verzendingswijzes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var basePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("OracleConnection");
            optionsBuilder.UseOracle(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("IVBUSER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Abonnement>(entity =>
        {
            entity.HasKey(e => e.Seqabonnement);

            entity.ToTable("ABONNEMENT");

            entity.Property(e => e.Seqabonnement)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("SEQABONNEMENT");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("CREDAT");
            entity.Property(e => e.Creusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CREUSR");
            entity.Property(e => e.Seqdiertype)
                .HasPrecision(2)
                .HasColumnName("SEQDIERTYPE");
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
        });

        modelBuilder.Entity<VeehouderAbonnement>(entity =>
        {
            entity.HasKey(e => new { e.Codveehouder, e.Seqdiertype });

            entity.ToTable("VEEHOUDER_ABONNEMENT");

            entity.Property(e => e.Codveehouder)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CODVEEHOUDER");
            entity.Property(e => e.Seqdiertype)
                .HasPrecision(2)
                .HasColumnName("SEQDIERTYPE");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("CREDAT");
            entity.Property(e => e.Creusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CREUSR");
            entity.Property(e => e.Dattot)
                .HasColumnType("DATE")
                .HasColumnName("DATTOT");
            entity.Property(e => e.Datvan)
                .HasColumnType("DATE")
                .HasColumnName("DATVAN");
            entity.Property(e => e.Faxnr)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("FAXNR");
            entity.Property(e => e.Seqabonnement)
                .HasPrecision(8)
                .HasColumnName("SEQABONNEMENT");
            entity.Property(e => e.Seqverzendingswijze)
                .HasPrecision(2)
                .HasColumnName("SEQVERZENDINGSWIJZE");
            entity.Property(e => e.Upddat)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("UPDDAT");
            entity.Property(e => e.Updusr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDUSR");
        });

        modelBuilder.Entity<Verzendingswijze>(entity =>
        {
            entity.HasKey(e => e.Seqverzendingswijze);

            entity.ToTable("VERZENDINGSWIJZE");

            entity.Property(e => e.Seqverzendingswijze)
                .HasPrecision(2)
                .HasColumnName("SEQVERZENDINGSWIJZE");
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
