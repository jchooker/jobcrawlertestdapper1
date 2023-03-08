using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace JobCrawler.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default") //generics! T,U - connectionId is name of connection string
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
            //the "using" and "return" commands here accomplish a LOT (via Dapper) re: communicating with SQL server
        }

        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "Default") //generics! T,U - connectionId is name of connection string
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}

