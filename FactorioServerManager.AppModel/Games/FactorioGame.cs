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
        public IList<Calendar> GameSchedule { get; }
        public IList<User> Owners { get; }
        public IList<User> Players { get; }

        public FactorioGame(string name, string description, IList<Calendar>? gameSchedule = null, List<User>? owners = null, IList<User>? players = null, int? id = null)
        {
            Id = id ?? -1;
            Name = name;
            Description = description;
            GameSchedule = gameSchedule ?? new List<Calendar>();
            Owners = owners ?? new List<User>();
            Players = players ?? new List<User>();
        }

        public FactorioGame(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            GameSchedule = Array.Empty<Calendar>();
            Owners = new List<User>();
            Players = new List<User>();
        }
    }
}
