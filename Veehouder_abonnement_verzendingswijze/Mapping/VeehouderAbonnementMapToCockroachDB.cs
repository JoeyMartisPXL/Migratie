using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;

namespace Veehouder_Abonnement_Verzendingswijze.Mapping
{
    public class VeehouderAbonnementMapToCockroachDB
    {
        public static List<VeehouderAbonnementCockroachDB> Map(VeehouderAbonnement[] veehouderabonnements)
        {
            List<VeehouderAbonnementCockroachDB> _cockroachDBs = new List<VeehouderAbonnementCockroachDB>();
            foreach (var veehouderabonnement in veehouderabonnements)
            {
                var cockroachDB = new VeehouderAbonnementCockroachDB()
                {
                    Codveehouder = veehouderabonnement.Codveehouder,
                    Credat = veehouderabonnement.Credat,
                    Creusr = veehouderabonnement.Creusr,
                    Dattot = veehouderabonnement.Dattot,
                    Datvan = veehouderabonnement.Datvan,
                    Faxnr = veehouderabonnement.Faxnr,
                    Seqabonnement = veehouderabonnement.Seqabonnement,
                    Seqdiertype = veehouderabonnement.Seqdiertype,
                    Seqverzendingswijze = veehouderabonnement.Seqverzendingswijze,
                    Upddat = veehouderabonnement.Upddat,
                    Updusr = veehouderabonnement.Updusr
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
