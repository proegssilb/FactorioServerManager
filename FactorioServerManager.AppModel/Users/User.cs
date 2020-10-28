using System;
using System.Collections.Generic;

namespace FactorioServerManager.AppModel.Users
{
    public class User
    {
        public string Identifier { get; }
        public Uri UserIcon { get; }
        public IReadOnlyList<FactorioIdentity> FactorioIdentities { get; }

        public User(string identifier, Uri userIcon, IReadOnlyList<FactorioIdentity>? factorioIdentities = null)
        {
            Identifier = identifier;
            FactorioIdentities = factorioIdentities ?? Array.Empty<FactorioIdentity>();
            UserIcon = userIcon;
        }
    }
}
