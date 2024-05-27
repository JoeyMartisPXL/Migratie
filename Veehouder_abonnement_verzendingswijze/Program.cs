using Npgsql;
using NPoco;
using Veehouder_Abonnement_Verzendingswijze.Mapping;
using Veehouder_Abonnement_Verzendingswijze.Models.ModelsOracle;
namespace Veehouder_abonnement_verzendingswijze
{
    public class Program
    {
        private const int BatchSize = 10000;

        static void Main(string[] args)
        {
            using var context = new IVBDBContext();

            ProcessAndInsertVerzendingswijze(context);

            ProcessAndInsertAbonnement(context);

            ProcessAndInsertVeehouderAbonnement(context);

        }

        private static void ProcessAndInsertAbonnement(IVBDBContext context)
        {
            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    int offset = 0;
                    List<Abonnement> abonnements;

                    while ((abonnements = GetAbonnementBatch(context, offset, BatchSize)).Count > 0)
                    {
                        db.BeginTransaction();
                        var mappedAbonnements = AbonnementMapToCockroachDB.Map(abonnements.ToArray());

                        foreach (var mappedAbonnement in mappedAbonnements)
                        {
                            db.Insert(mappedAbonnement);
                        }
                        db.CompleteTransaction();
                        offset += BatchSize;
                    }
                    Console.WriteLine("Abonnements successfully inserted");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Failed to connect to database: {ex.Message}");
            }


        }

        private static void ProcessAndInsertVeehouderAbonnement(IVBDBContext context)
        {
            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    int offset = 0;
                    List<VeehouderAbonnement> veehouderAbonnements;

                    while ((veehouderAbonnements = GetVeehouderAbonnementBatch(context, offset, BatchSize)).Count > 0)
                    {
                        db.BeginTransaction();
                        var mappedveehouderAbonnements = VeehouderAbonnementMapToCockroachDB.Map(veehouderAbonnements.ToArray());

                        foreach (var mappedVeehouderAbonnement in mappedveehouderAbonnements)
                        {
                            db.Insert(mappedVeehouderAbonnement);
                        }

                        db.CompleteTransaction();
                        offset += BatchSize;
                    }
                    Console.WriteLine("VeehouderAbonnements successfully inserted");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Failed to connect to database: {ex.Message}");
            }
        }

        private static void ProcessAndInsertVerzendingswijze(IVBDBContext context)
        {
            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    int offset = 0;
                    List<Verzendingswijze> verzendingswijzes;

                    while ((verzendingswijzes = GetVerzendingswijzeBatch(context, offset, BatchSize)).Count > 0)
                    {
                        db.BeginTransaction();
                        var mappedVerzendingswijzes = VerzendingswijzeMapToCockroachDB.Map(verzendingswijzes.ToArray());

                        foreach (var mappedVerzendingswijze in mappedVerzendingswijzes)
                        {
                            db.Insert(mappedVerzendingswijze);
                        }

                        db.CompleteTransaction();
                        offset += BatchSize;
                    }
                    Console.WriteLine("Verzendingswijzes successfully inserted");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Failed to connect to database: {ex.Message}");
            }
        }


        private static List<Verzendingswijze> GetVerzendingswijzeBatch(IVBDBContext context, int offset, int batchSize)
        {
            return context.Verzendingswijzes
              .OrderBy(dt => dt.Seqverzendingswijze)
              .Skip(offset)
              .Take(batchSize)
              .ToList();
        }

        private static List<Abonnement> GetAbonnementBatch(IVBDBContext context, int offset, int batchSize)
        {
            return context.Abonnements
                          .OrderBy(dt => dt.Seqabonnement)
                          .Skip(offset)
                          .Take(batchSize)
                          .ToList();
        }

        private static List<VeehouderAbonnement> GetVeehouderAbonnementBatch(IVBDBContext context, int offset, int batchSize)
        {
            return context.VeehouderAbonnements
                          .Skip(offset)
                          .Take(batchSize)
                          .ToList();
        }
    }
}
