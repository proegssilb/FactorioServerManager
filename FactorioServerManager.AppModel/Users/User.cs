using System;
using System.Collections.Generic;

namespace FactorioServerManager.AppModel.Users
{
    public class User
    {
        public string Identifier { get; }
        public string DisplayName { get; }
        public Uri UserIcon { get; }
        public IReadOnlyList<FactorioIdentity> FactorioIdentities { get; }

        public User(string identifier, string displayName, Uri userIcon, IReadOnlyList<FactorioIdentity>? factorioIdentities = null)
        {
            Identifier = identifier;
            DisplayName = displayName;
            FactorioIdentities = factorioIdentities ?? Array.Empty<FactorioIdentity>();
            UserIcon = userIcon;
        }

        public User(string identifier, string displayName, string userIcon, IReadOnlyList<FactorioIdentity>? factorioIdentities = null)
            : this(identifier, displayName, new Uri(userIcon), factorioIdentities)
        {

        }

        public User(string identifier, string name, string icon)
            : this(identifier, name, new Uri(icon))
        {

        }
    }
}
