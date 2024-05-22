using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Document_Documenttype.Models.ModelsOracle;

public partial class IVBDBContext : DbContext
{
    public IVBDBContext()
    {
    }

    public IVBDBContext(DbContextOptions<IVBDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Documenttype> Documenttypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=IVBUSER;Password=IVB;Data Source=localhost:1521/IVB;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("IVBUSER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Seqdocument);

            entity.ToTable("DOCUMENT");

            entity.Property(e => e.Seqdocument)
                .HasPrecision(15)
                .ValueGeneratedNever()
                .HasColumnName("SEQDOCUMENT");
            entity.Property(e => e.Bericht)
                .HasColumnType("CLOB")
                .HasColumnName("BERICHT");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("CREDAT");
            entity.Property(e => e.Creusr)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("'USER'")
                .HasColumnName("CREUSR");
            entity.Property(e => e.Documentguid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOCUMENTGUID");
            entity.Property(e => e.Mailopenedcount)
                .HasColumnType("NUMBER")
                .HasColumnName("MAILOPENEDCOUNT");
            entity.Property(e => e.Mailopeneddate)
                .HasColumnType("DATE")
                .HasColumnName("MAILOPENEDDATE");
            entity.Property(e => e.Seqdocumenttype)
                .HasPrecision(15)
                .HasColumnName("SEQDOCUMENTTYPE");
            entity.Property(e => e.Seqlang)
                .HasPrecision(8)
                .HasDefaultValueSql("1")
                .HasColumnName("SEQLANG");
            entity.Property(e => e.Upddat)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("UPDDAT");
            entity.Property(e => e.Updusr)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("'USER'")
                .HasColumnName("UPDUSR");

            /*            entity.HasOne(d => d.SeqdocumenttypeNavigation).WithMany(p => p.Documents)
                            .HasForeignKey(d => d.Seqdocumenttype)
                            .HasConstraintName("FK_DOC_DOCTYPE");*/
        });

        modelBuilder.Entity<Documenttype>(entity =>
        {
            entity.HasKey(e => e.Seqdocumenttype);

            entity.ToTable("DOCUMENTTYPE");

            entity.Property(e => e.Seqdocumenttype)
                .HasPrecision(15)
                .ValueGeneratedNever()
                .HasColumnName("SEQDOCUMENTTYPE");
            entity.Property(e => e.Beschrijving)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("BESCHRIJVING");
            entity.Property(e => e.Credat)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("CREDAT");
            entity.Property(e => e.Creusr)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("'USER'")
                .HasColumnName("CREUSR");
            entity.Property(e => e.Emailmaintemplate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAILMAINTEMPLATE");
            entity.Property(e => e.Pdfmaintemplate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PDFMAINTEMPLATE");
            entity.Property(e => e.Priority)
                .HasPrecision(15)
                .HasColumnName("PRIORITY");
            entity.Property(e => e.SeqtransTitle)
                .HasPrecision(8)
                .HasColumnName("SEQTRANS_TITLE");
            entity.Property(e => e.Upddat)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("UPDDAT");
            entity.Property(e => e.Updusr)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("'USER'")
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
