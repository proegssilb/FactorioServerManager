using Dapper;
using FactorioServerManager.AppModel.Games;
using FactorioServerManager.AppModel.Users;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace FactorioServerManager.DataStore.Games
{
    public class FactorioGameRepository : IFactorioGameRepository
    {
        private readonly ISqlConnectionProvider _connectionProvider;
        private readonly ILogger _logger;

        public FactorioGameRepository(ISqlConnectionProvider connectionProvider, ILogger<FactorioGameRepository> logger)
        {
            _connectionProvider = connectionProvider;
            _logger = logger;
        }

        public IEnumerable<FactorioGame> ListGames(User currentUser, int pageSize, int page)
        {
            const string query = @"
    SELECT FactorioGames.Id, FactorioGames.Name, FactorioGames.Description
    FROM FactorioGames
        INNER JOIN game_members ON (FactorioGames.id = game_members.gameid)
        INNER JOIN Users ON (users.id = game_members.userid)
    WHERE 
        users.identifier = @userId
    GROUP BY FactorioGames.Id, FactorioGames.Name, FactorioGames.Description
    LIMIT @pageSize
    OFFSET @start
";
            using DbConnection dbconn = _connectionProvider.GetDbConnection();

            try
            {
                return dbconn.Query<FactorioGame>(query, new { userId = currentUser.Identifier, pageSize, start = page * pageSize });
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "Exception while retrieving list of games for user {0}", currentUser.Identifier);
            }
            return Array.Empty<FactorioGame>();
        }
    }
}
