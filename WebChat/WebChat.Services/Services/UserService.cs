using System.Collections.Generic;
using WebChat.Domain.Entities;
using WebChat.Infra.Interfaces;
using WebChat.Services.Interfaces;

namespace WebChat.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Save(User user)
        {
            return _userRepository.Save(user);
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public IList<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public User GetByHash(string hash)
        {
            return _userRepository.GetByHash(hash);
        }
    }
}
