using System;
using System.Collections.Generic;

namespace Haarkleur.Models.ModelsOracle;

public partial class Haarkleur
{
    public int Codhaarkleur { get; set; }

    public int Seqtrans { get; set; }

    public string Code { get; set; } = null!;

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string Creusr { get; set; } = null!;

    public string Updusr { get; set; } = null!;
}
