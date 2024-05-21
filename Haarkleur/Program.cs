using Haarkleur.DatabaseConnection;
using Haarkleur.Mapping;
using Haarkleur.Models;
using Haarkleur.Models.ModelsOracle;
using Npgsql;
using NPoco;
using System;
using System.Linq;

namespace Haarkleur
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new IVBDbContext();
            var haarkleuren = context.Haarkleurs.ToArray();

            var haarkleurenMap = HaarkleurMapToCockroachDB.Map(haarkleuren);

            var database = new DatabaseCockroachDB();
            string connectionString = database.GetConnectionString();
            try {
            using (var db = new Database(connectionString, DatabaseType.PostgreSQL, Npgsql.NpgsqlFactory.Instance))
            {
                db.BeginTransaction();

                foreach (var item in haarkleurenMap)
                {
                    db.Insert(item);
                }

                db.CompleteTransaction();
            } }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Failed to connect to database: {ex.Message}");
            }
        }
    }
}
