using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Threading.Tasks;
namespace TestBericht.DAL
{
    public class OracleDataAccess
    {
        private readonly string _connectionString;

        public OracleDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection");
        }

        public async Task<string> GetClobContentAsync()
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new OracleCommand("SELECT bericht FROM DOCUMENT WHERE SEQDOCUMENT = 791", connection))
                {
                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess);

                    if (await reader.ReadAsync())
                    {
                        return reader.GetString(0);
                    }

                    return string.Empty;
                }
            }
        }
    }

}
