using NPoco;
using System;
using System.Collections.Generic;

namespace Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;
[TableName("veehouder_abonnement")]
[PrimaryKey("codveehouder, seqdiertype", AutoIncrement = false)]
public partial class VeehouderAbonnementCockroachDB
{
    [Column("codveehouder")]
    public string Codveehouder { get; set; } = string.Empty;

    [Column("seqdiertype")]
    public byte Seqdiertype { get; set; }

    [Column("seqabonnement")]
    public int Seqabonnement { get; set; }

    [Column("datvan")]
    public DateTime Datvan { get; set; }

    [Column("dattot")]
    public DateTime? Dattot { get; set; }

    private DateTime credat;
    [Column("credat")]
    public DateTime Credat
    {
        get => credat;
        set => credat = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    private DateTime upddat;
    [Column("upddat")]
    public DateTime Upddat
    {
        get => upddat;
        set => upddat = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    [Column("creusr")]
    public string? Creusr { get; set; }

    [Column("updusr")]
    public string? Updusr { get; set; }

    [Column("seqverzendingswijze")]
    public byte Seqverzendingswijze { get; set; }

    [Column("faxnr")]
    public string? Faxnr { get; set; }

    /*    public virtual Abonnement SeqabonnementNavigation { get; set; } = null!;

        public virtual Verzendingswijze SeqverzendingswijzeNavigation { get; set; } = null!;*/
}
