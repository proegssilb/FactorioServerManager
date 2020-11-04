using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FactorioServerManager.AppModel.Users
{
    public interface IAuthService
    {
        User? WhoAmI();
        void SetAnonymousSession(string? sessionId = null);
        void SetAuthenticatedSession(string sessionId, JwtSecurityToken jwt);
        void SetAuthenticatedSession(string sessionId, ClaimsPrincipal user);
        bool IsSessionReady();
        bool IsSessionReady(string expectedSessionId);
        void LogoutSession();
    }
}
