using System.Collections.Generic;

namespace FactorioServerManager.AppModel.Users
{
    public interface IUserService
    {
        User? GetUser(string userIdentifier);
        IReadOnlyList<User> GetUsers(IEnumerable<string> userIdentifiers);
        void SaveUser(User currentUser);
    }
}
