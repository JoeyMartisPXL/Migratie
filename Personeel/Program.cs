using Npgsql;
using NPoco;
using Personeel.DatabaseConnection;
using Personeel.Mapping;
using Personeel.Models.ModelsOracle;

namespace Personeel
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new IVBDBContext();
            var personeel = context.Personeels.ToArray();
            var personeelMap = PersoneelMapToCockroachDB.Map(personeel);
            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();
            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    db.BeginTransaction();

                    foreach (var item in personeelMap)
                    {
                        db.Insert(item);
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
