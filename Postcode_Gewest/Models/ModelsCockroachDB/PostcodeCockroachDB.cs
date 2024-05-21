using NPoco;
using System;

namespace Postcode_Gewest.Models.ModelsCockroachDB
{
    [TableName("postcode")]
    [PrimaryKey("codpostcode", AutoIncrement = false)]
    public class PostcodeCockroachDB
    {
        [Column("codpostcode")]
        public int Codpostcode { get; set; }

        [Column("van")]
        public int Van { get; set; }

        [Column("tot")]
        public int Tot { get; set; }

        [Column("codgewest")]
        public int Codgewest { get; set; }
    }
}
