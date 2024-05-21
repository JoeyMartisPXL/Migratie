using Npgsql;
using NPoco;
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
            var gewests = context.Gewests.ToArray();
            var gewestMap = GewestMapToCockroachDB.Map(gewests);

            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();

            try
            {
                using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
                {
                    db.BeginTransaction();

                    foreach (var gewest in gewestMap)
                    {
                        db.Execute($"INSERT INTO gewest (codgewest, naam) VALUES ({gewest.Codgewest}, @0)", gewest.Naam);
                    }

                    foreach (var postcode in postcodeMap)
                    {
                        db.Execute($"INSERT INTO postcode (codpostcode, van, tot, codgewest) VALUES ({postcode.Codpostcode}, @0, @1, {postcode.Codgewest})", postcode.Van, postcode.Tot);
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
