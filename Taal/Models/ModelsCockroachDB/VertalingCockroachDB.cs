using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taal.Models.ModelsCockroachDB
{
    [TableName("vertaling")]
    [PrimaryKey("seqtrans, seqlang", AutoIncrement = false)]
    public partial class VertalingCockroachDB
    {
        [Column("seqtrans")]
        public int Seqtrans { get; set; }

        [Column("seqlang")]

        public int Seqlang { get; set; }

        private DateTime credat;
        [Column("credat")]
        public DateTime Credat
        {
            get => credat;
            set => credat = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        private DateTime upddat;

        [Column("upddat")]
        public DateTime Upddat
        {
            get => upddat;
            set => upddat = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        [Column("creusr")]
        public string? Creusr { get; set; }

        [Column("updusr")]
        public string? Updusr { get; set; }

        
        [Column("translat")]
        public string? Translat { get; set; }
    }
}
