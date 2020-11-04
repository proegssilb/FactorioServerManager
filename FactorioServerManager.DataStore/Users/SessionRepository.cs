using FactorioServerManager.AppModel.Users;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.DataStore.Users
{
    class SessionRepository : ISessionRepository
    {
        private readonly IConnectionMultiplexer _redisMultiplexer;
        private const string UserNameField = "SessionUser";
        private const string SessionIdField = "SessionId";
        private const string SessionKeyPrefix = "FSM-session-";
        private readonly TimeSpan SessionExpiration = new TimeSpan(14, 0, 0, 0);

        public SessionRepository(IConnectionMultiplexer redisConnection)
        {
            _redisMultiplexer = redisConnection;
        }

        public RawSession? LoadSession(string sessionId)
        {
            IDatabase redisDb = _redisMultiplexer.GetDatabase();
            HashEntry[]? response = redisDb.HashGetAll($"{SessionKeyPrefix}{sessionId}");
            if (response == null || response.Length == 0)
            {
                // Technically response should never be null, but we already know how to handle it if it is.
                return null;
            }
            string foundSessionId = "";
            string foundUserId = "";
            foreach (HashEntry entry in response)
            {
                switch (entry.Name)
                {
                    case UserNameField:
                        foundUserId = entry.Value;
                        break;
                    case SessionIdField:
                        foundSessionId = entry.Value;
                        break;
                    default:
                        break;
                }
            }
            if (string.IsNullOrEmpty(foundUserId) || string.IsNullOrEmpty(foundSessionId) || foundSessionId != sessionId)
            {
                throw new SessionExpiredException();
            }
            return new RawSession(foundSessionId, foundUserId);
        }

        public void StoreSession(RawSession sessionToStore)
        {
            IDatabase redisDb = _redisMultiplexer.GetDatabase();
            string redisKey = $"{SessionKeyPrefix}{sessionToStore.SessionId}";
            redisDb.HashSet(redisKey, new[] {
                new HashEntry(UserNameField, sessionToStore.UserId),
                new HashEntry(SessionIdField, sessionToStore.SessionId)
            });
            redisDb.KeyExpire(redisKey, DateTime.Now.Add(SessionExpiration));
        }

        public void DeleteSession(string sessionId)
        {
            IDatabase redisDb = _redisMultiplexer.GetDatabase();
            string redisKey = $"{SessionKeyPrefix}{sessionId}";
            redisDb.KeyDelete(redisKey);
        }
    }
}
