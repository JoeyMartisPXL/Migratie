using System;
using System.Collections.Generic;

namespace Taal.Models.ModelsOracle;

public partial class Vertaling
{
    public int Seqtrans { get; set; }

    public int Seqlang { get; set; }

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string? Creusr { get; set; }

    public string? Updusr { get; set; }

    public string? Translat { get; set; }

    //public virtual Vertalinglink SeqtransNavigation { get; set; } = null!;

    //public virtual ICollection<Taal> Taals { get; set; } = new List<Taal>();
}
