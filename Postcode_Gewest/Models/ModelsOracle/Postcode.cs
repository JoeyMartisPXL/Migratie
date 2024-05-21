using System;
using System.Collections.Generic;

namespace Postcode_Gewest.Models.ModelsOracle;

public partial class Postcode
{
    public int Codpostcode { get; set; }

    public int Van { get; set; }

    public int Tot { get; set; }

    public int Codgewest { get; set; }
/*
    public virtual Gewest CodgewestNavigation { get; set; } = null!;*/
}
