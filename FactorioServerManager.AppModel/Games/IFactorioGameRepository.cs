using System.Collections.Generic;
using FactorioServerManager.AppModel.Users;

namespace FactorioServerManager.AppModel.Games
{
    public interface IFactorioGameRepository
    {
        public IEnumerable<FactorioGame> ListGames(User currentUser, int pageSize, int page);
    }
}
