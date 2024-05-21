using NPoco;
using System;

namespace Haarkleur.Models.ModelsCockroachDB
{
    [TableName("haarkleur")]
    [PrimaryKey("codhaarkleur", AutoIncrement = false)]
    public partial class HaarkleurCockroachDB
    {
        [Column("codhaarkleur")]
        public int Codhaarkleur { get; set; }

        [Column("seqtrans")]
        public int Seqtrans { get; set; }

        [Column("code")]
        public string Code { get; set; } = null!;

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
        public string Creusr { get; set; } = null!;

        [Column("updusr")]
        public string Updusr { get; set; } = null!;
    }
}
