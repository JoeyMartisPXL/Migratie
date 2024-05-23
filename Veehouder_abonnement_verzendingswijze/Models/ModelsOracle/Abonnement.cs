using System;
using System.Collections.Generic;

namespace Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;

public partial class Abonnement
{
    public int Seqabonnement { get; set; }

    public int? Seqtrans { get; set; }

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string? Creusr { get; set; }

    public string? Updusr { get; set; }

    public byte Seqdiertype { get; set; }

   /* public virtual ICollection<VeehouderAbonnement> VeehouderAbonnements { get; set; } = new List<VeehouderAbonnement>();*/
}
