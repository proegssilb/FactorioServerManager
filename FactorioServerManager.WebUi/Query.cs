using FactorioServerManager.AppModel.Games;
using FactorioServerManager.AppModel.Users;
using HotChocolate;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace FactorioServerManager.WebUi
{
    public class Query
    {
        public Greetings GetGreetings() => new Greetings();
        public AuthQuery GetAuth([Service] AuthQuery authQuery) => authQuery;
        public IReadOnlyList<FactorioGame> GetGames([Service] IFactorioGameService gameService) => gameService.ListGames();
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

        public string WhoAmI([Service] IHttpContextAccessor contextAccessor)
        {
            string? userId = contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _authService.WhoAmI()?.DisplayName ?? userId ?? "";
        }
    }
}
