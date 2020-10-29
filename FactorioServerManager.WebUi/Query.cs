using FactorioServerManager.AppModel.Users;
using HotChocolate;

namespace FactorioServerManager.WebUi
{
    public class Query
    {
        public Greetings GetGreetings() => new Greetings();
        public AuthQuery GetAuth([Service] AuthQuery authQuery) => authQuery;
    }

    public class Greetings
    {
        public string Hello() => "World";
    }

    public class AuthQuery
    {
        private readonly IAuthService _authService;

        public AuthQuery(IAuthService authService)
        {
            _authService = authService;
        }

        public string WhoAmI() => _authService.WhoAmI()?.Identifier ?? "";
    }
}
