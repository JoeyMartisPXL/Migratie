using NPoco;
using System;
using System.Collections.Generic;

namespace Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;
[TableName("abonnement")]
[PrimaryKey("seqabonnement")]
public partial class AbonnementCockroachDB
{
    [Column("seqabonnement")]
    public int Seqabonnement { get; set; }

    [Column("seqtrans")]
    public int? Seqtrans { get; set; }

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

    [Column("seqdiertype")]
    public byte Seqdiertype { get; set; }
}

