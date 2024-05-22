using Document_Documenttype.DatabaseConnection;
using Document_Documenttype.Mapping;
using Document_Documenttype.Models.ModelsOracle;
using Npgsql;
using NPoco;

namespace Document_Documenttype
{
    public class Program
    {
        private const int BatchSize = 1000;

        static void Main(string[] args)
        {
            using var context = new IVBDBContext();

            /*ProcessAndInsertDocumentTypes(context);*/

            // Process and insert documents
            ProcessAndInsertDocuments(context);
        }

        private static void ProcessAndInsertDocumentTypes(IVBDBContext context)
        {
            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    db.BeginTransaction();

                    int offset = 0;
                    List<Documenttype> documenttypes;

                    while ((documenttypes = GetDocumentTypesBatch(context, offset, BatchSize)).Count > 0)
                    {
                        var mappedDocumenttypes = DocumenttypeMapToCockroachDB.Map(documenttypes.ToArray());

                        foreach (var documenttype in mappedDocumenttypes)
                        {
                            db.Insert(documenttype);
                        }

                        offset += BatchSize;
                    }

                    db.CompleteTransaction();
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Failed to connect to database: {ex.Message}");
            }
        }

        private static void ProcessAndInsertDocuments(IVBDBContext context)
        {
            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    int offset = 0;
                    List<Document> documents;

                    while ((documents = GetDocumentsBatch(context, offset, BatchSize)).Count > 0)
                    {
                        db.BeginTransaction();
                        var mappedDocuments = DocumentMapToCockroachDB.Map(documents.ToArray());

                        foreach (var document in mappedDocuments)
                        {
                            db.Insert(document);
                        }

                        db.CompleteTransaction();
                        offset += BatchSize;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Failed to connect to database: {ex.Message}");
            }
        }

        private static List<Documenttype> GetDocumentTypesBatch(IVBDBContext context, int offset, int batchSize)
        {
            return context.Documenttypes
                          .OrderBy(dt => dt.Seqdocumenttype)
                          .Skip(offset)
                          .Take(batchSize)
                          .ToList();
        }

        private static List<Document> GetDocumentsBatch(IVBDBContext context, int offset, int batchSize)
        {
            return context.Documents
                          .OrderBy(d => d.Seqdocument)
                          .Skip(offset)
                          .Take(batchSize)
                          .ToList();
        }
    }
}
