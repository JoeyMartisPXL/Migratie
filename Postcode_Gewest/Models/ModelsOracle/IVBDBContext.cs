using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Postcode_Gewest.Models.ModelsOracle;

public partial class IVBDBContext : DbContext
{
    public IVBDBContext()
    {
    }

    public IVBDBContext(DbContextOptions<IVBDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gewest> Gewests { get; set; }

    public virtual DbSet<Postcode> Postcodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=IVBUSER;Password=IVB;Data Source=localhost:1521/IVB;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("IVBUSER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Gewest>(entity =>
        {
            entity.HasKey(e => e.Codgewest).HasName("SYS_C008979");

            entity.ToTable("GEWEST");

            entity.HasIndex(e => e.Naam, "GEWEST_UNIQUE").IsUnique();

            entity.Property(e => e.Codgewest)
                .HasColumnType("NUMBER")
                .HasColumnName("CODGEWEST");
            entity.Property(e => e.Naam)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAAM");
        });

        modelBuilder.Entity<Postcode>(entity =>
        {
            entity.HasKey(e => e.Codpostcode).HasName("SYS_C009125");

            entity.ToTable("POSTCODE");

            entity.HasIndex(e => new { e.Van, e.Tot }, "VAN_TOT_UNIQUE").IsUnique();

            entity.Property(e => e.Codpostcode)
                .HasColumnType("NUMBER")
                .HasColumnName("CODPOSTCODE");
            entity.Property(e => e.Codgewest)
                .HasColumnType("NUMBER")
                .HasColumnName("CODGEWEST");
            entity.Property(e => e.Tot)
                .HasPrecision(4)
                .HasColumnName("TOT");
            entity.Property(e => e.Van)
                .HasPrecision(4)
                .HasColumnName("VAN");

            entity.HasOne(d => d.CodgewestNavigation).WithMany(p => p.Postcodes)
                .HasForeignKey(d => d.Codgewest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GEWEST");
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
