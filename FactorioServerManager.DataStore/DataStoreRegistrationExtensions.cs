using Dapper;
using DapperExtensions;
using DapperExtensions.Sql;
using FactorioServerManager.AppModel.Games;
using FactorioServerManager.AppModel.Users;
using FactorioServerManager.DataStore.Games;
using FactorioServerManager.DataStore.Users;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace FactorioServerManager.DataStore
{
    public static class DataStoreRegistrationExtensions
    {
        public static IServiceCollection RegisterServerManagerRepositories(this IServiceCollection serviceCollection, RedisConfig redisConfig)
        {
            RegisterDapper();
            serviceCollection.AddSingleton<ISessionRepository, SessionRepository>();
            serviceCollection.AddSingleton<IUserRepository, UserRepository>();
            serviceCollection.AddSingleton<IFactorioGameRepository, FactorioGameRepository>();
            serviceCollection.AddSingleton<ISqlConnectionProvider, SqlConnectionProvider>();
            serviceCollection.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConfig.ConnectionString));
            return serviceCollection;
        }

        private static void RegisterDapper()
        {
            SqlMapper.AddTypeHandler(new UriTypeHandler());
            DapperExtensions.DapperExtensions.SqlDialect = new PostgreSqlDialect();
            DapperAsyncExtensions.SqlDialect = new PostgreSqlDialect();
        }
    }
}
