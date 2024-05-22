using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
namespace Taal.Models.ModelsCockroachDB
{

    [TableName("TAAL")]
    [PrimaryKey("SEQLANG", AutoIncrement = false)]
    public partial class TaalCockroachDB
    {
        [Column("SEQLANG")]
        public int Seqlang { get; set; }

        [Column("SEQTRANS")]
        public int? Seqtrans { get; set; }

        [Column("CREDAT")]
        public DateTime Credat { get; set; }

        
        [Column("UPDDAT")]
        public DateTime Upddat { get; set; }

        [Column("CREUSR")]
        public string? Creusr { get; set; }


        [Column("UPDUSR")]
        public string? Updusr { get; set; }
    }

}
