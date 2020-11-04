using FactorioServerManager.AppLogic.Games;
using FactorioServerManager.AppLogic.Users;
using FactorioServerManager.AppModel.Games;
using FactorioServerManager.AppModel.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FactorioServerManager.AppLogic
{
    public static class AppLogicRegistrationExtensions
    {
        public static IServiceCollection RegisterServerManagerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAuthService, AuthService>();
            serviceCollection.AddSingleton<IUserService, UserService>();
            serviceCollection.AddSingleton<ISessionService, SessionService>();
            serviceCollection.AddSingleton<IFactorioGameService, FactorioGameService>();
            return serviceCollection;
        }
    }
}
