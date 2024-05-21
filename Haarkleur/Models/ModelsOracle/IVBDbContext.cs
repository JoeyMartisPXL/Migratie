using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Haarkleur.Models.ModelsOracle;

public partial class IVBDbContext : DbContext
{
    public IVBDbContext()
    {
    }

    public IVBDbContext(DbContextOptions<IVBDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Haarkleur> Haarkleurs { get; set; }

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

        modelBuilder.Entity<Haarkleur>(entity =>
        {
            entity.HasKey(e => e.Codhaarkleur);

            entity.ToTable("HAARKLEUR");

            entity.Property(e => e.Codhaarkleur)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("CODHAARKLEUR");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CODE");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("SYSDATE ")
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
                .HasDefaultValueSql("SYSDATE ")
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
