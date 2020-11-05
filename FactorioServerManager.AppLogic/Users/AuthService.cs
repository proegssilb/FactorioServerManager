using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace FactorioServerManager.AppLogic.Users
{
    public class AuthService : IAuthService
    {
        private readonly ISessionService _sessionService;
        private readonly IUserService _userService;
        private readonly ISessionRepository _sessionRepository;
        private readonly Auth0Secrets _auth0Config;

        public AuthService(ISessionService sessionService, IUserService userService, ISessionRepository sessionRepository, Auth0Secrets secretsConfig)
        {
            _sessionService = sessionService;
            _userService = userService;
            _sessionRepository = sessionRepository;
            _auth0Config = secretsConfig;
        }

        public bool IsSessionReady()
        {
            RawSession? storedSession = _sessionService.GetCurrentSession();
            return storedSession != null;
        }

        public bool IsSessionReady(string expectedSessionId)
        {
            RawSession? storedSession = _sessionService.GetCurrentSession();
            return storedSession != null && storedSession.SessionId == expectedSessionId;
        }

        public void LogoutSession()
        {
            string sessionId = _sessionService.GetCurrentSessionId();
            _sessionRepository.DeleteSession(sessionId);
        }

        public void SetAnonymousSession(string? sessionId = null)
        {
            sessionId ??= _sessionService.GetCurrentSessionId();
            if (!string.IsNullOrEmpty(sessionId))
            {
                _sessionRepository.StoreSession(new RawSession(sessionId, ""));
            }
        }

        public void SetAuthenticatedSession(string sessionId, JwtSecurityToken jwt)
        {
            // We're going to trust that the jwt is crypto-valid, chrono-valid, and struct-valid.
            if (jwt.Issuer != $"https://{_auth0Config.Domain}/")
            {
                // Came from the wrong place.
                return;
            }
            if (!jwt.Audiences.Contains(_auth0Config.ClientId))
            {
                // Wasn't issued to us.
                return;
            }

            InternalSetAuthenticatedSession(sessionId, jwt.Subject, jwt.Claims);
        }

        public void SetAuthenticatedSession(string sessionId, ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
            {
                SetAnonymousSession(sessionId);
                return;
            }
            string? username = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            InternalSetAuthenticatedSession(sessionId, username, user.Claims);
        }

        private void InternalSetAuthenticatedSession(string sessionId, string userId, IEnumerable<Claim> claims)
        {
            User? loadedUser = _userService.GetUser(userId);
            User currentUser;

            if (loadedUser != null)
            {
                currentUser = loadedUser;
            }
            else
            {
                Uri userIcon = new Uri("/defaultAvatar.png");
                string? displayName = null;
                string? email = null;

                foreach (Claim userClaim in claims)
                {
                    switch (userClaim.Type)
                    {
                        case "picture":
                        case "avatar":
                            userIcon = new Uri(userClaim.Value);
                            break;
                        case "name":
                        case ClaimTypes.Name:
                            displayName = userClaim.Value;
                            break;
                        case "email":
                        case ClaimTypes.Email:
                            email = userClaim.Value;
                            break;
                        default:
                            continue;
                    }
                }

                currentUser = new User(null, userId, displayName ?? email ?? "", userIcon);
            }

            _sessionRepository.StoreSession(new RawSession(sessionId, currentUser.Identifier));
        }

        public User? WhoAmI()
        {
            RawSession? currentSession = _sessionService.GetCurrentSession();
            string? userId = currentSession?.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }
            else
            {
                return _userService.GetUser(userId ?? "");
            }
        }
    }
}
