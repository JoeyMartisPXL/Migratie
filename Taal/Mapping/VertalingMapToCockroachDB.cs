using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taal.Models.ModelsCockroachDB;
using Taal.Models.ModelsOracle;

namespace Taal.Mapping
{
    public class VertalingMapToCockroachDB
    {
        public static List<VertalingCockroachDB> Map(Vertaling[] vertalingen)
        {
            List<VertalingCockroachDB> _cockroachDBs = new List<VertalingCockroachDB>();
            foreach (var vertaling in vertalingen)
            {
                var cockroachDB = new VertalingCockroachDB
                {
                    Credat = vertaling.Credat,
                    Seqlang = vertaling.Seqlang,
                    Translat = vertaling.Translat,
                    Creusr = vertaling.Creusr,
                    Seqtrans = vertaling.Seqtrans,
                    Upddat = vertaling.Upddat,
                    Updusr = vertaling.Updusr,
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
