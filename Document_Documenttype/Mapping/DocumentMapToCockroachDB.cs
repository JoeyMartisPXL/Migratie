using Document_Documenttype.Models.ModelsCockroachDB;
using Document_Documenttype.Models.ModelsOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Documenttype.Mapping
{
    public class DocumentMapToCockroachDB
    {
        public static List<DocumentCockroachDB> Map(Document[] documents)
        {
            List<DocumentCockroachDB> _cockroachDBs = new List<DocumentCockroachDB>();
            foreach (var document in documents)
            {
                var cockroachDB = new DocumentCockroachDB
                {
                    Documentguid = document.Documentguid,
                    Seqdocument = document.Seqdocument,
                    Seqdocumenttype = document.Seqdocumenttype,
                    Bericht = document.Bericht,
                    Credat = document.Credat,
                    Creusr = document.Creusr,
                    Mailopenedcount = document.Mailopenedcount,
                    Mailopeneddate = document.Mailopeneddate,
                    Seqlang = document.Seqlang,
                    Upddat = document.Upddat,
                    Updusr = document.Updusr
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
