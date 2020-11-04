using System;
using System.Linq;
using FactorioServerManager.DataStore;
using FactorioServerManager.DataStore.Users.Migrations;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FactorioServerManager.Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                //.AddUserSecrets("290e06cd-07d3-430a-8887-03b28aa73ad1")
                .AddUserSecrets("0feda0b0-e2f3-4c5c-820f-cdf631d5d6f9")
                .Build();
            SqlConfig sqlConfig = new SqlConfig();
            config.GetSection("sql").Bind(sqlConfig);

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    //.AddSQLite()
                    .AddPostgres()
                    .WithGlobalConnectionString(sqlConfig.ConnectionString)
                    .ScanIn(DataStoreAssembly.Value).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .AddSingleton(sqlConfig)
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}
