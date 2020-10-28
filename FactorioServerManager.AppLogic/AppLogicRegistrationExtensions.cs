using FactorioServerManager.AppLogic.Users;
using FactorioServerManager.AppModel.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.AppLogic
{
    public static class AppLogicRegistrationExtensions
    {
        public static IServiceCollection RegisterServerManagerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAuthService, AuthService>();
            serviceCollection.AddSingleton<IUserService, UserService>();
            serviceCollection.AddSingleton<ISessionService, SessionService>();
            return serviceCollection;
        }
    }
}
