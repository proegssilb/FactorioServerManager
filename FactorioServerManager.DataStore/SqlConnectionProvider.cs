using Npgsql;
using System.Data.Common;

namespace FactorioServerManager.DataStore
{
    internal class SqlConnectionProvider : ISqlConnectionProvider
    {
        private readonly SqlConfig _config;

        public SqlConnectionProvider(SqlConfig config)
        {
            _config = config;
        }

        public DbConnection GetDbConnection()
        {
            return new NpgsqlConnection(_config.ConnectionString);
        }
    }
}
