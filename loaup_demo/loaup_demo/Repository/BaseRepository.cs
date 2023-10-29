using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
// ----------------------------------------------------
// fileName : BaseRepository.cs
// description : 
// create : 2023-10-16
// update : 
// ----------------------------------------------------
namespace loaup_demo.Repository
{
    public interface BaseRepository
    {

    }

    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration, string connectionString)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString(connectionString);
        }

        public IDbConnection OpenConnection() => new SqlConnection("DEV_LOAUP");
    }
}