using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.AppLogic.Users
{
    public class Auth0Secrets
    {
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string Domain { get; set; } = "";
    }
}
