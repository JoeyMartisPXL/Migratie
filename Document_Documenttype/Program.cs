using Document_Documenttype.DatabaseConnection;
using Document_Documenttype.Mapping;
using Document_Documenttype.Models.ModelsOracle;
using Npgsql;
using NPoco;

namespace Document_Documenttype
{



    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new IVBDBContext();

            // Documents data mapping
            var documents = DocumentMapToCockroachDB.Map(context.Documents.ToArray());

            // Documenttypes data mapping
            var documenttypes = DocumenttypeMapToCockroachDB.Map(context.Documenttypes.ToArray());

            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    db.BeginTransaction();

                    foreach (var documenttype in documenttypes)
                    {
                        db.Insert(documenttype);
                    }

/*                    var existingSeqtrans = new HashSet<int>();
                    foreach (var vertalinglink in vertalinglinksMap)
                    {
                        existingSeqtrans.Add(vertalinglink.Seqtrans);
                    }*/

                    foreach (var document in documents)
                    {
/*                        if (existingSeqtrans.Contains(vertaling.Seqtrans))
                        {*/
                            db.Insert(document);
/*                        }*/

                    }


                    db.CompleteTransaction();
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Failed to connect to database: {ex.Message}");
            }
        }
    }
}
