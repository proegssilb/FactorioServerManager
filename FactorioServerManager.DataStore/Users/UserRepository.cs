using Dapper;
using FactorioServerManager.AppModel.Users;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;

namespace FactorioServerManager.DataStore.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionProvider _connectionProvider;

        public UserRepository(ISqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }
        public IReadOnlyList<User> GetUsers(IEnumerable<string> userIdentifiers)
        {
            const string query = @"
SELECT Id, Identifier, Name, Icon 
FROM Users
WHERE Identifier=ANY(@ids)
";
            using DbConnection connection = _connectionProvider.GetDbConnection();
            return connection.Query<User>(query, new { ids = userIdentifiers }).ToList();
        }

        public void SaveUser(User userToSave)
        {
            const string query = @"
INSERT INTO Users(Identifier, Name, Icon)
VALUES (@Identifier, @DisplayName, @UserIcon)
ON CONFLICT(Identifier) DO UPDATE SET Name=excluded.Name, Icon=excluded.Icon
";

            using DbConnection connection = _connectionProvider.GetDbConnection();
            connection.Query(query, userToSave);
        }
    }
}
