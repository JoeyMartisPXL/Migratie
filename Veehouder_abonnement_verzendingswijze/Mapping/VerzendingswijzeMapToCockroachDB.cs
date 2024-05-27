using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;

namespace Veehouder_Abonnement_Verzendingswijze.Mapping
{
    public class VerzendingswijzeMapToCockroachDB
    {
        public static List<VerzendingswijzeCockroachDB> Map(Verzendingswijze[] verzendingswijzes)
        {
            List<VerzendingswijzeCockroachDB> _cockroachDBs = new List<VerzendingswijzeCockroachDB>();
            foreach (var verzendingswijze in verzendingswijzes)
            {
                var cockroachDB = new VerzendingswijzeCockroachDB()
                {
                    Credat = verzendingswijze.Credat,
                    Creusr = verzendingswijze.Creusr,
                    Seqtrans = verzendingswijze.Seqtrans,
                    Seqverzendingswijze = verzendingswijze.Seqverzendingswijze,
                    Upddat = verzendingswijze.Upddat,
                    Updusr = verzendingswijze.Updusr
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }

    }
}
