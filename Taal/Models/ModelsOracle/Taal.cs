using System;
using System.Collections.Generic;

namespace Taal.Models.ModelsOracle;

public partial class Taal
{
    public int Seqlang { get; set; }

    public int? Seqtrans { get; set; }

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string? Creusr { get; set; }

    public string? Updusr { get; set; }

/*    public virtual Vertaling? Vertaling { get; set; }*/
}
