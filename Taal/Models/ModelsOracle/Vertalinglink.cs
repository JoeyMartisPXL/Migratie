using System;
using System.Collections.Generic;

namespace Taal.Models.ModelsOracle;

public partial class Vertalinglink
{
    public int Seqtrans { get; set; }

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string? Creusr { get; set; }

    public string? Updusr { get; set; }

    /*public virtual ICollection<Vertaling> Vertalings { get; set; } = new List<Vertaling>();*/
}
