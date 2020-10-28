using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using FactorioServerManager.AppLogic;
using FactorioServerManager.DataStore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using FactorioServerManager.AppLogic.Users;

namespace FactorioServerManager.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            RedisConfig redisConfig = new RedisConfig();
            Auth0Secrets auth0Config = new Auth0Secrets();
            _configuration.GetSection("redis").Bind(redisConfig);
            _configuration.GetSection("Auth0Secrets").Bind(auth0Config);

            services.RegisterServerManagerServices()
                    .RegisterServerManagerRepositories(redisConfig)
                    .AddSingleton(auth0Config)
                    .AddSingleton<Query>();

            // enable InMemory messaging services for subscription support.
            services.AddInMemorySubscriptions();

            // this enables you to use DataLoader in your resolvers.
            services.AddDataLoaderRegistry();

            // Add GraphQL Services
            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddAuthorizeDirectiveType()
                    .AddQueryType<Query>());

            services.AddSingleton<AuthQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseRouting()
                .UseWebSockets()
                .UseGraphQL()
                .UsePlayground()
                .UseVoyager()
                .UseGraphiQL();
        }
    }
}
