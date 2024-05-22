using Npgsql;
using NPoco;
using Taal.DatabaseConnection;
using Taal.Mapping;
using Taal.Models.ModelsOracle;

namespace Taal
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new IVBDbContext();

            // Vertalinglinks data mapping
            var vertalinglinksMap = VertalinglinkMapToCockroachDB.Map(context.Vertalinglinks.ToArray());

            // Vertalingen data mapping
            var vertalingenMap = VertalingMapToCockroachDB.Map(context.Vertalings.ToArray());
            
            // Talen data mapping
            var talenMap = TaalMapToCockroachDB.Map(context.Taals.ToArray());

            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    db.BeginTransaction();

                    foreach (var vertalinglink in vertalinglinksMap)
                    {
                        db.Insert(vertalinglink);
                    }

                    var existingSeqtrans = new HashSet<int>();
                    foreach (var vertalinglink in vertalinglinksMap)
                    {
                        existingSeqtrans.Add(vertalinglink.Seqtrans);
                    }
                    
                    foreach (var vertaling in vertalingenMap)
                    {
                        if(existingSeqtrans.Contains(vertaling.Seqtrans)){
                            db.Insert(vertaling);
                        }

                    }
                    foreach (var taal in talenMap)
                    {
                        db.Insert(taal);
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
