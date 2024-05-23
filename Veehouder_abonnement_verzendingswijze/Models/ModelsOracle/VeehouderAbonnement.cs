using System;
using System.Collections.Generic;

namespace Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;

public partial class VeehouderAbonnement
{
    public string Codveehouder { get; set; } = null!;

    public byte Seqdiertype { get; set; }

    public int Seqabonnement { get; set; }

    public DateTime Datvan { get; set; }

    public DateTime? Dattot { get; set; }

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string? Creusr { get; set; }

    public string? Updusr { get; set; }

    public byte Seqverzendingswijze { get; set; }

    public string? Faxnr { get; set; }

/*    public virtual Abonnement SeqabonnementNavigation { get; set; } = null!;

    public virtual Verzendingswijze SeqverzendingswijzeNavigation { get; set; } = null!;*/
}
