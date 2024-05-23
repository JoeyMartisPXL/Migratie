using Document_Documenttype.Models.ModelsCockroachDB;
using Document_Documenttype.Models.ModelsOracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Documenttype.Mapping
{
    public class DocumenttypeMapToCockroachDB
    {
        public static List<DocumenttypeCockroachDB> Map(Documenttype[] documenttypes)
        {
            List<DocumenttypeCockroachDB> _cockroachDBs = new List<DocumenttypeCockroachDB>();
            foreach (var documenttype in documenttypes)
            {
                var cockroachDB = new DocumenttypeCockroachDB
                {
                   Seqdocumenttype = documenttype.Seqdocumenttype,
                   Beschrijving = documenttype.Beschrijving,
                   Credat = documenttype.Credat,
                   Creusr = documenttype.Creusr,
                   Emailmaintemplate = documenttype.Emailmaintemplate,
                   Pdfmaintemplate = documenttype.Pdfmaintemplate,
                   Priority = documenttype.Priority,
                   SeqtransTitle = documenttype.SeqtransTitle,
                   Upddat = documenttype.Upddat,
                   Updusr = documenttype.Updusr
                };

                _cockroachDBs.Add(cockroachDB);
            }
            return _cockroachDBs;
        }
    }
}
