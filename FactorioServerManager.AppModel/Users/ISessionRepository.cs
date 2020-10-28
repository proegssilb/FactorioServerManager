using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.AppModel.Users
{
    public interface ISessionRepository
    {
        void StoreSession(RawSession sessionToStore);
        RawSession? LoadSession(string SessionId);
    }
}
