using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorioServerManager.AppLogic.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionService _sessionService;

        public UserService(IUserRepository userRepository, ISessionService sessionService)
        {
            _userRepository = userRepository;
            _sessionService = sessionService;
        }

        public User? GetUser(string userIdentifier)
        {
            return GetUsers(new[] { userIdentifier }).FirstOrDefault();
        }

        public IReadOnlyList<User> GetUsers(IEnumerable<string> userIdentifiers)
        {
            return _userRepository.GetUsers(userIdentifiers);
        }

        public void SaveUser(User userToSave)
        {
            _userRepository.SaveUser(userToSave);
        }
    }
}
