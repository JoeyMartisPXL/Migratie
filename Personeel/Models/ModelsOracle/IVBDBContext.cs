using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Personeel.Models.ModelsOracle;

public partial class IVBDBContext : DbContext
{
    public IVBDBContext()
    {
    }

    public IVBDBContext(DbContextOptions<IVBDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personeel> Personeels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=IVBUSER;Password=IVB;Data Source=localhost:1521/IVB;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("IVBUSER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Personeel>(entity =>
        {
            entity.HasKey(e => e.Codpersoneel);

            entity.ToTable("PERSONEEL");

            entity.Property(e => e.Codpersoneel)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CODPERSONEEL");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("CREDAT");
            entity.Property(e => e.Creusr)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CREUSR");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Islockedout)
                .IsRequired()
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(1)")
                .HasColumnName("ISLOCKEDOUT");
            entity.Property(e => e.Naam)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NAAM");
            entity.Property(e => e.Nbrtrylogin)
                .IsRequired()
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(1)")
                .HasColumnName("NBRTRYLOGIN");
            entity.Property(e => e.Rijksregisternummer)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RIJKSREGISTERNUMMER");
            entity.Property(e => e.Taal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAAL");
            entity.Property(e => e.Upddat)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("UPDDAT");
            entity.Property(e => e.Updusr)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("UPDUSR");
            entity.Property(e => e.Voornaam)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("VOORNAAM");
            entity.Property(e => e.Webpw)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WEBPW");
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
