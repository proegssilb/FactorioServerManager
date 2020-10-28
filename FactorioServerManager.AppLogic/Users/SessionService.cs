using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FactorioServerManager.AppLogic.Users
{
    public class SessionService : ISessionService
    {
        private readonly AsyncLocal<string> _currentSessionId = new AsyncLocal<string>();
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public RawSession? GetCurrentSession()
        {
            string sessionId = GetCurrentSessionId();
            if (string.IsNullOrEmpty(sessionId))
            {
                return null;
            }
            return _sessionRepository.LoadSession(sessionId);
        }

        public string GetCurrentSessionId()
        {
            return _currentSessionId.Value;
        }

        public void SetCurrentSessionId(string sessionId)
        {
            _currentSessionId.Value = sessionId;
        }
    }
}
