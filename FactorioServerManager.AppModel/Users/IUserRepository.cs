using System.Collections.Generic;

namespace FactorioServerManager.AppModel.Users
{
    public interface IUserRepository
    {
        IReadOnlyList<User> GetUsers(IEnumerable<string> userIdentifiers);
        void SaveUser(User userToSave);
    }
}
