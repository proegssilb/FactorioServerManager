using System;
using System.Collections.Generic;

namespace FactorioServerManager.AppModel.Users
{
    public class User
    {
        public long? Id { get; } = null;
        public string Identifier { get; }
        public string DisplayName { get; }
        public Uri UserIcon { get; }
        public IReadOnlyList<FactorioIdentity> FactorioIdentities { get; }

        public User(long? id, string identifier, string displayName, Uri userIcon, IReadOnlyList<FactorioIdentity>? factorioIdentities = null)
        {
            Id = id;
            Identifier = identifier;
            DisplayName = displayName;
            FactorioIdentities = factorioIdentities ?? Array.Empty<FactorioIdentity>();
            UserIcon = userIcon;
        }

        public User(string identifier, string displayName, string userIcon, IReadOnlyList<FactorioIdentity>? factorioIdentities = null)
            : this(null, identifier, displayName, new Uri(userIcon), factorioIdentities)
        {

        }

        public User(long id, string identifier, string name, string icon)
            : this(id, identifier, name, new Uri(icon))
        {

        }
    }
}
