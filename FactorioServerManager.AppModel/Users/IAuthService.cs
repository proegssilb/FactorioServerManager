using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.AppModel.Users
{
    public interface IAuthService
    {
        User? WhoAmI();
        void SetAnonymousSession(string? sessionId = null);
        void SetAuthenticatedSession(string sessionId, object jwt);
        bool IsSessionReady();
        bool IsSessionReady(string expectedSessionId);
    }
}
