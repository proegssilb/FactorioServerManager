using FactorioServerManager.AppModel.Users;
using System;

namespace FactorioServerManager.AppModel.Calendars
{
    public class Calendar
    {
        public Uri Location { get; }
        public string Name { get; }
        public string Description { get; }
        public User Owner { get; }

        public Calendar(Uri location, string name, string description, User owner)
        {
            Location = location;
            Name = name;
            Description = description;
            Owner = owner;
        }
    }
}
