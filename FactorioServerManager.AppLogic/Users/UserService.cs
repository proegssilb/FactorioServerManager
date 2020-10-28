using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IReadOnlyList<User> GetUsers(IEnumerable<string> userIdentifiers)
        {
            throw new NotImplementedException();
        }
    }
}
