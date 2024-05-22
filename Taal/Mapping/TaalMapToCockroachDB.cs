using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taal.Models.ModelsCockroachDB;
using Taal.Models.ModelsOracle;

namespace Taal.Mapping
{
    public class TaalMapToCockroachDB
    {
        public static List<TaalCockroachDB> Map(Models.ModelsOracle.Taal[] talen)
        {
            List<TaalCockroachDB> _cockroachDBs = new List<TaalCockroachDB>();
            foreach (var taal in talen)
            {
                var cockroachDB = new TaalCockroachDB
                {
                    Credat = taal.Credat,
                    Seqlang = taal.Seqlang,
                    Creusr = taal.Creusr,
                    Seqtrans = taal.Seqtrans,
                    Upddat = taal.Upddat,
                    Updusr = taal.Updusr,
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
