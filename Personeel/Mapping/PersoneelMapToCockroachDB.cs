
using Personeel.Models.ModelsCockroachDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Personeel.Mapping
{
    public class PersoneelMapToCockroachDB
    {
        public static List<PersoneelCockroachDB> Map(Models.ModelsOracle.Personeel[] personeels)
        {
            List<PersoneelCockroachDB> _cockroachDBs = new List<PersoneelCockroachDB>();
            foreach (var personeel in personeels)
            {
                var cockroachDB = new PersoneelCockroachDB
                {
                    Codpersoneel =  personeel.Codpersoneel,
                    Credat = personeel.Credat,
                    Upddat = personeel.Upddat,
                    Naam = personeel.Naam,
                    Voornaam = personeel.Voornaam,
                    Webpw = personeel.Webpw,
                    Email = personeel.Email,
                    Rijksregisternummer = personeel.Rijksregisternummer,
                    Taal = personeel.Taal,
                    Nbrtrylogin = personeel.Nbrtrylogin,
                    Islockedout = personeel.Islockedout
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
