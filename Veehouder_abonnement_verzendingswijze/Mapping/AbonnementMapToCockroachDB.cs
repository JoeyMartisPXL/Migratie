using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;

namespace Veehouder_Abonnement_Verzendingswijze.Mapping
{
    public class AbonnementMapToCockroachDB
    {
        public static List<AbonnementCockroachDB> Map(Abonnement[] abonnements)
        {
            List<AbonnementCockroachDB> _cockroachDBs = new List<AbonnementCockroachDB>();
            foreach (var abonnement in abonnements)
            {
                var cockroachDB = new AbonnementCockroachDB()
                {
                    Credat = abonnement.Credat,
                    Creusr = abonnement.Creusr,
                    Seqabonnement = abonnement.Seqabonnement,
                    Seqdiertype = abonnement.Seqdiertype,
                    Seqtrans = abonnement.Seqtrans,
                    Upddat = abonnement.Upddat,
                    Updusr  = abonnement.Updusr
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
