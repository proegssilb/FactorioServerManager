using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;

namespace FactorioServerManager.AppModel.Games
{
    public interface IFactorioGameService
    {
        IReadOnlyList<FactorioGame> ListGames(int pageSize = 20, int page = 0);
        void AddPlayerToGame(FactorioGame selectedGame, string newPlayerId);
        void AddOwnerToGame(FactorioGame selectedGame, string newOwnerId);
        void AssociateCalendar(FactorioGame selectedGame, Uri calendarUri);
    }
}
