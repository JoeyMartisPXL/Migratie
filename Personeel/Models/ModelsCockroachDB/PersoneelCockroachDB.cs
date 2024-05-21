using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personeel.Models.ModelsCockroachDB
{
    [TableName("personeel")]
    [PrimaryKey("codpersoneel", AutoIncrement = false)]
    public partial class PersoneelCockroachDB
    {
        [Column("codpersoneel")]
        public string Codpersoneel { get; set; } = null!;

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
        
        [Column("naam")]
        public string? Naam { get; set; }
        
        [Column("voornaam")]
        public string? Voornaam { get; set; }
        
        [Column("webpw")]
        public string? Webpw { get; set; }
        
        [Column("email")]
        public string? Email { get; set; }
       
        [Column("rijksregisternummer")]
        public string? Rijksregisternummer { get; set; }

        [Column("taal")]
        public string Taal { get; set; } = null!;

        [Column("nbrtrylogin")]
        public bool? Nbrtrylogin { get; set; }

        [Column("islockedout")]
        public bool? Islockedout { get; set; }
    }
}
