using Postcode_Gewest.Models.ModelsCockroachDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postcode_Gewest.Mapping
{
    public class PostcodeMapToCockroachDB
    {
        public static List<PostcodeCockroachDB> Map(IEnumerable<Models.ModelsOracle.Postcode> postcodes)
        {
            var cockroachDBList = new List<PostcodeCockroachDB>();
            foreach (var postcode in postcodes)
            {
                var cockroachDB = new PostcodeCockroachDB
                {
                    Codpostcode = (int)postcode.Codpostcode,
                    Van = (int)postcode.Van,
                    Tot = (int)postcode.Tot,
                    Codgewest = (int)postcode.Codgewest
                };
                cockroachDBList.Add(cockroachDB);
            }
            return cockroachDBList;
        }
    }
}
