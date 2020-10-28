using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.AppModel.Users
{
    public interface ISessionService
    {
        void SetCurrentSessionId(string sessionId);
        string GetCurrentSessionId();
        RawSession? GetCurrentSession();
    }
}
