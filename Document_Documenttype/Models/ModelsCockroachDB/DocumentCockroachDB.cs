using System;
using NPoco;

namespace Document_Documenttype.Models.ModelsCockroachDB
{
    [TableName("document")]
    [PrimaryKey("seqdocument", AutoIncrement = false)]
    public class DocumentCockroachDB
    {
        [Column("seqdocument")]
        public long Seqdocument { get; set; }

        [Column("creusr")]
        public string? Creusr { get; set; }

        [Column("updusr")]
        public string? Updusr { get; set; }

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

        [Column("bericht")]
        public string? Bericht { get; set; }

        [Column("documentguid")]
        public string? Documentguid { get; set; }

        [Column("mailopenedcount")]
        public decimal? Mailopenedcount { get; set; }

        private DateTime? mailopeneddate;
        [Column("mailopeneddate")] // Corrected column name
        public DateTime? Mailopeneddate
        {
            get => mailopeneddate;
            set => mailopeneddate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : (DateTime?)null;
        }

        [Column("seqdocumenttype")]
        public long? Seqdocumenttype { get; set; }

        [Column("seqlang")]
        public int? Seqlang { get; set; }
    }
}
