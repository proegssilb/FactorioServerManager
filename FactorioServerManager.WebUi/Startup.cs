using FactorioServerManager.AppLogic;
using FactorioServerManager.AppLogic.Users;
using FactorioServerManager.DataStore;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;

namespace FactorioServerManager.WebUi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterConfig(services, out Auth0Secrets auth0config);

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(14);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.RegisterServerManagerServices()
                    .AddSingleton<Query>()
                    .AddSingleton<OpenIdConnectEventHandler>();

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

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
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect("Auth0", ConfigureOidcOptions(auth0config));
        }

        private void RegisterConfig(IServiceCollection services, out Auth0Secrets auth0config)
        {
            RedisConfig redisConfig = new RedisConfig();
            auth0config = new Auth0Secrets();
            SqlConfig sqlConfig = new SqlConfig();
            Configuration.GetSection("redis").Bind(redisConfig);
            Configuration.GetSection("Auth0Secrets").Bind(auth0config);
            Configuration.GetSection("sql").Bind(sqlConfig);

            services.RegisterServerManagerRepositories(redisConfig)
                    .AddSingleton(sqlConfig)
                    .AddSingleton(auth0config);
        }

        private static Action<OpenIdConnectOptions> ConfigureOidcOptions(Auth0Secrets auth0Config)
        {
            void Configurator(OpenIdConnectOptions options)
            {
                // Set the authority to your Auth0 domain
                options.Authority = $"https://{auth0Config.Domain}";

                // Configure the Auth0 Client ID and Client Secret
                options.ClientId = auth0Config.ClientId;
                options.ClientSecret = auth0Config.ClientSecret;

                // Set response type to code
                options.ResponseType = OpenIdConnectResponseType.Code;

                // Configure the scope
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");

                // Set the callback path, so Auth0 will call back to http://localhost:3000/callback
                // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard
                options.CallbackPath = new PathString("/callback");

                // Configure the Claims Issuer to be Auth0
                options.ClaimsIssuer = "Auth0";
                options.EventsType = typeof(OpenIdConnectEventHandler);
            }

            return Configurator;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseSession(new SessionOptions() { IdleTimeout = new TimeSpan(12, 0, 0, 0) });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<SessionManagerMiddleware>();

            app.UseWebSockets()
               .UseGraphQL("/graphql")
               .UseGraphiQL("/graphql");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });


        }
    }
}
