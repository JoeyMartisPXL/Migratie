using NPoco;

namespace Taal.Models.ModelsCockroachDB
{

    [TableName("vertalinglink")]
    [PrimaryKey("seqtrans", AutoIncrement = false)]
    public partial class VertalinglinkCockroachDB
    {
        [Column("seqtrans")]
        public int Seqtrans { get; set; }

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
    }

}
