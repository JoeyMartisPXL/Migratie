using Postcode_Gewest.Models.ModelsCockroachDB;
using Postcode_Gewest.Models.ModelsOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postcode_Gewest.Mapping
{
    public class GewestMapToCockroachDB
    {
        public static List<GewestCockroachDB> Map(Gewest[] gewests)
        {
            var cockroachDBList = new List<GewestCockroachDB>();
            foreach (var gewest in gewests)
            {
                var cockroachDB = new GewestCockroachDB
                {
                    Codgewest = gewest.Codgewest,
                    Naam = gewest.Naam
                };
                cockroachDBList.Add(cockroachDB);
            }
            return cockroachDBList;
        }
    }
}
