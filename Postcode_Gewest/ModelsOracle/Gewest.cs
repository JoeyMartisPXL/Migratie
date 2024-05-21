using System;
using System.Collections.Generic;

namespace Postcode_Gewest.ModelsOracle;

public partial class Gewest
{
    public decimal Codgewest { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Postcode> Postcodes { get; set; } = new List<Postcode>();
}
