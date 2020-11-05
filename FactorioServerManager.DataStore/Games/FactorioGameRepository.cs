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
    SELECT fg.Id, fg.Name, fg.Description, gm2.Id, gm2.GameId, gm2.UserId, gm2.MemberType, u2.Id, u2.Identifier, u2.Name, u2.Icon
    FROM FactorioGames fg
        INNER JOIN game_members gm1 ON (fg.id = gm1.gameid)
        INNER JOIN Users u1 ON (u1.id = gm1.userid)
        LEFT OUTER JOIN game_members gm2 ON (fg.id = gm2.gameid)
        INNER JOIN Users u2 ON (gm2.userid = u2.id)
    WHERE 
        u1.identifier = @userId
    GROUP BY fg.Id, fg.Name, fg.Description, gm2.Id, gm2.GameId, gm2.UserId, gm2.MemberType, u2.Id, u2.Identifier, u2.Name, u2.Icon
    LIMIT @pageSize
    OFFSET @start
";
            Dictionary<long, FactorioGame> gamesFound = new Dictionary<long, FactorioGame>();

            using DbConnection dbconn = _connectionProvider.GetDbConnection();

            try
            {
                return dbconn.Query<FactorioGame, GameUserMap, User, FactorioGame>(query, (game, userMap, user) =>
                {
                    if (!gamesFound.TryGetValue(game.Id, out var foundGame))
                    {
                        gamesFound[game.Id] = game;
                        foundGame = game;
                    }
                    if (user != null)
                    {
                        if (userMap?.MemberType == GameMemberTypes.Owner)
                        {
                            foundGame.Owners.Add(user);
                        }
                        else
                        {
                            foundGame.Players.Add(user);
                        }
                    }
                    return foundGame;
                }, new { userId = currentUser.Identifier, pageSize, start = page * pageSize });
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "Exception while retrieving list of games for user {0}", currentUser.Identifier);
            }
            return Array.Empty<FactorioGame>();
        }
    }
}
