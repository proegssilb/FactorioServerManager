using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.AppModel.Users
{
    public class Session
    {
        public string SessionId { get; }

        public User? AuthenticatedUser { get; }

        public Session(string sessionId, User? authenticatedUser)
        {
            SessionId = sessionId;
            AuthenticatedUser = authenticatedUser;
        }
    }
}
