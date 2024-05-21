using Npgsql;
using NPoco;
using P.DatabaseConnection;
using Personeel.DatabaseConnection;
using Personeel.Mapping;
using Personeel.Models.ModelsOracle;
using Postcode_Gewest.DatabaseConnection;
using Postcode_Gewest.Mapping;
using Postcode_Gewest.Models.ModelsOracle;
using System;

namespace Postcode_Gewest
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new IVBDBContext();

            // Postcode data migration
            var postcodes = context.Postcodes.ToArray();
            var postcodeMap = PostcodeMapToCockroachDB.Map(postcodes);

            // Personeel data migration
            var gewest = context.Gewests.ToArray();
            var gewestMap = GewestCockroachDB.Map(gewest);

            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    db.BeginTransaction();

                    foreach (var item in postcodeMap)
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
