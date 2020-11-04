using System.Data.Common;

namespace FactorioServerManager.DataStore
{
    public interface ISqlConnectionProvider
    {
        DbConnection GetDbConnection();
    }
}