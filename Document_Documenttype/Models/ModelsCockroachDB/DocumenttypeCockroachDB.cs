using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Documenttype.Models.ModelsCockroachDB
{
    [TableName("documenttype")]
    [PrimaryKey("seqdocumenttype", AutoIncrement = false)]
    public class DocumenttypeCockroachDB
    {
        [Column("seqdocumenttype")]
        public long Seqdocumenttype { get; set; }
        [Column("beschrijving")]
        public string? Beschrijving { get; set; }
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
        [Column("emailmaintemplate")]
        public string? Emailmaintemplate { get; set; }
        [Column("pdfmaintemplate")]
        public string? Pdfmaintemplate { get; set; }
        [Column("priority")]
        public long? Priority { get; set; }
        [Column("seqtrans_title")]
        public int? SeqtransTitle { get; set; }

    }
}
