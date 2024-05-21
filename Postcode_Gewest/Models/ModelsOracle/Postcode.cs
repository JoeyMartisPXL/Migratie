using System;
using System.Collections.Generic;

namespace Postcode_Gewest.Models.ModelsOracle;

public partial class Postcode
{
    public decimal Codpostcode { get; set; }

    public byte Van { get; set; }

    public byte Tot { get; set; }

    public decimal Codgewest { get; set; }

    public virtual Gewest CodgewestNavigation { get; set; } = null!;
}
