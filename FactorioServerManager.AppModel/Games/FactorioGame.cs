using FactorioServerManager.AppModel.Calendars;
using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;

namespace FactorioServerManager.AppModel.Games
{
    public class FactorioGame
    {
        public long Id { get; } = -1;
        public string Name { get; }
        public string Description { get; }
        public IReadOnlyList<Calendar> GameSchedule { get; }
        public IReadOnlyList<User> Owners { get; }
        public IReadOnlyList<User> Players { get; }

        public FactorioGame(string name, string description, IReadOnlyList<Calendar>? gameSchedule = null, IReadOnlyList<User>? owners = null, IReadOnlyList<User>? players = null, int? id = null)
        {
            Id = id ?? -1;
            Name = name;
            Description = description;
            GameSchedule = gameSchedule ?? Array.Empty<Calendar>();
            Owners = owners ?? Array.Empty<User>();
            Players = players ?? Array.Empty<User>();
        }

        public FactorioGame(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            GameSchedule = Array.Empty<Calendar>();
            Owners = Array.Empty<User>();
            Players = Array.Empty<User>();
        }
    }
}
