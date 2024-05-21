using Haarkleur.Models.ModelsCockroachDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haarkleur.Mapping
{
    public class HaarkleurMapToCockroachDB
    {
        public static List<HaarkleurCockroachDB> Map(Models.ModelsOracle.Haarkleur[] haarkleuren)
        {
            List<HaarkleurCockroachDB> _cockroachDBs = new List<HaarkleurCockroachDB>();
            foreach (var haarkleur in haarkleuren)
            {
                var cockroachDB = new HaarkleurCockroachDB
                {
                    Codhaarkleur = haarkleur.Codhaarkleur,
                    Seqtrans = haarkleur.Seqtrans,
                    Code = haarkleur.Code,
                    Credat = haarkleur.Credat,
                    Upddat = haarkleur.Upddat,
                    Creusr = haarkleur.Creusr,
                    Updusr = haarkleur.Updusr
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
