using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.AppModel.Users
{
    public class RawSession
    {
        public string SessionId { get; }
        public string UserId { get; }

        public RawSession(string sessionId, string userId)
        {
            SessionId = sessionId;
            UserId = userId;
        }
    }
}
