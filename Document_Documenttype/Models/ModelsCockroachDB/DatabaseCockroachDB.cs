using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Document_Documenttype.DatabaseConnection
{
    public class DatabaseCockroachDB
    {
        private string _connectionString;

        public DatabaseCockroachDB()
        {
            // Set the base path to the project directory
            var basePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("CockroachDbConnectionLocal");
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
