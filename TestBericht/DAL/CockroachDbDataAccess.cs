using Npgsql;

namespace TestBericht.DAL
{
    public class CockroachDbDataAccess
    {
        private readonly string _connectionString;

        public CockroachDbDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CockroachDbConnectionLocal");
        }

        public async Task<string> GetStringContentAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand("SELECT bericht FROM DOCUMENT WHERE SEQDOCUMENT = 791", connection))
                {
                    var result = await command.ExecuteScalarAsync();

                    return result?.ToString() ?? string.Empty;
                }
            }
        }
    }

}
