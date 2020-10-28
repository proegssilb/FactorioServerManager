namespace FactorioServerManager.AppModel.Users
{
    public class FactorioIdentity
    {
        public string Username { get; }
        public string? Token { get; }

        public FactorioIdentity(string username, string? token = null)
        {
            Username = username;
            Token = token;
        }
    }
}