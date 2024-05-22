using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taal.Models.ModelsCockroachDB;
using Taal.Models.ModelsOracle;

namespace Taal.Mapping
{
    public class VertalinglinkMapToCockroachDB
    {
        public static List<VertalinglinkCockroachDB> Map(Vertalinglink[] vertalinglinks)
        {
            List<VertalinglinkCockroachDB> _cockroachDBs = new List<VertalinglinkCockroachDB>();
            foreach (var vertaling in vertalinglinks)
            {
                var cockroachDB = new VertalinglinkCockroachDB
                {
                    Seqtrans = vertaling.Seqtrans,
                    Credat = vertaling.Credat,
                    Upddat = vertaling.Upddat,
                    Creusr = vertaling.Creusr,
                    Updusr = vertaling.Updusr,
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
