using FactorioServerManager.AppModel.Users;
using FactorioServerManager.DataStore.Users;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.DataStore
{
    public static class DataStoreRegistrationExtensions
    {
        public static IServiceCollection RegisterServerManagerRepositories(this IServiceCollection serviceCollection, RedisConfig redisConfig)
        {
            serviceCollection.AddSingleton<ISessionRepository, SessionRepository>();
            serviceCollection.AddSingleton<IUserRepository, UserRepository>();
            serviceCollection.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConfig.ConnectionString));
            return serviceCollection;
        }
    }
}
