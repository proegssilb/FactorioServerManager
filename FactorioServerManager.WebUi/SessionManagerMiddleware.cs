using FactorioServerManager.AppModel.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FactorioServerManager.WebUi
{
    public class SessionManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISessionService _sessionService;
        private readonly IAuthService _authService;

        public SessionManagerMiddleware(RequestDelegate next, ISessionService sessionService, IAuthService authService)
        {
            _next = next;
            _sessionService = sessionService;
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context != null)
            {
                string sessionId = "";
                try
                {
                    sessionId = context.Session.Id ?? "";
                }
                catch (InvalidOperationException)
                {
                }
                if (context.Session.Keys.Contains("n"))
                {
                    _sessionService.SetCurrentSessionId(sessionId);
                }
                else
                {
                    // New session.
                    context.Session.SetString("n", Guid.NewGuid().ToString());
                    _authService.SetAuthenticatedSession(sessionId, context.User);
                }

            }

            await _next(context);

            _sessionService.UnloadCurrentSesion();
        }
    }
}
