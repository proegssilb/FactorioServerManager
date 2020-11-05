using FactorioServerManager.AppModel.Games;
using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorioServerManager.AppLogic.Games
{
    class FactorioGameService : IFactorioGameService
    {
        private readonly IFactorioGameRepository _gameRepository;
        private readonly IAuthService _authService;

        public FactorioGameService(IFactorioGameRepository gameRepository, IAuthService authService)
        {
            _gameRepository = gameRepository;
            _authService = authService;
        }
        public void AddOwnerToGame(FactorioGame selectedGame, string newOwnerId)
        {
            throw new NotImplementedException();
        }

        public void AddPlayerToGame(FactorioGame selectedGame, string newPlayerId)
        {
            throw new NotImplementedException();
        }

        public void AssociateCalendar(FactorioGame selectedGame, Uri calendarUri)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<FactorioGame> ListGames(int pageSize = 20, int page = 0)
        {
            User? currentUser = _authService.WhoAmI();
            if (currentUser == null)
            {
                return new List<FactorioGame>();
            }
            return _gameRepository.ListGames(currentUser, pageSize, page).Distinct().ToList();
        }
    }
}
