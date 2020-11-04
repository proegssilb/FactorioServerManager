using FactorioServerManager.AppLogic.Users;
using FactorioServerManager.AppModel.Users;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace FactorioServerManager.WebUi
{
    internal class OpenIdConnectEventHandler : OpenIdConnectEvents
    {
        private readonly Auth0Secrets _auth0Config;
        private readonly ISessionService _sesionService;
        private readonly IAuthService _authService;

        public OpenIdConnectEventHandler(Auth0Secrets auth0Config, ISessionService sesionService, IAuthService authService)
        {
            _auth0Config = auth0Config;
            _sesionService = sesionService;
            _authService = authService;

            OnRedirectToIdentityProviderForSignOut = OnOidcLogoutRedirect;
            OnTokenValidated = OnJwtValidated;
        }

        public Task OnOidcLogoutRedirect(RedirectContext context)
        {
            var logoutUri = $"https://{_auth0Config.Domain}/v2/logout?client_id={_auth0Config.ClientId}";

            var postLogoutUri = context.Properties.RedirectUri;
            if (!string.IsNullOrEmpty(postLogoutUri))
            {
                if (postLogoutUri.StartsWith("/"))
                {
                    // transform to absolute
                    var request = context.Request;
                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                }
                logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
            }

            context.Response.Redirect(logoutUri);
            context.HandleResponse();

            return Task.CompletedTask;
        }


        public Task OnJwtValidated(TokenValidatedContext arg)
        {
            if (arg.SecurityToken == null)
            {
                return Task.CompletedTask;
            }

            JwtSecurityToken token = arg.SecurityToken;
            string sessionId = arg.HttpContext.Session.Id;
            _authService.SetAuthenticatedSession(sessionId, token);
            arg.HttpContext.Session.SetString("token", token.RawData);
            return Task.CompletedTask;
        }
    }
}