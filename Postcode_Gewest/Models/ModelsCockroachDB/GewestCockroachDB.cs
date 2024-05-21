using System;
using System.Collections.Generic;

namespace Postcode_Gewest.Models.ModelsOracle;

public partial class GewestCockroachDB
{
    public decimal Codgewest { get; set; }

    public string Naam { get; set; } = null!;

    /*public virtual ICollection<Postcode> Postcodes { get; set; } = new List<Postcode>();*/

}
