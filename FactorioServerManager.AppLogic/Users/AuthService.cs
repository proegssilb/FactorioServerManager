using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;
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

        public void SetAnonymousSession(string? sessionId = null)
        {
            sessionId ??= _sessionService.GetCurrentSessionId();
            if (!string.IsNullOrEmpty(sessionId))
            {
                _sessionRepository.StoreSession(new RawSession(sessionId, ""));
            }
        }

        public void SetAuthenticatedSession(string sessionId, object jwt)
        {

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
