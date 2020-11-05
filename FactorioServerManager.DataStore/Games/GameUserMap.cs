using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.DataStore.Games
{
    internal class GameUserMap
    {
        public long Id { get; set; }
        public long GameId { get; set; }
        public long UserId { get; set; }
        public GameMemberTypes MemberType { get; set; }
    }
}
