using System.Collections.Generic;
using WebChat.Infra.Entities;

namespace WebChat.Infra.Interfaces
{
    public interface IUserRepository
    {
        User Save(User user);
        IList<User> GetAll();
        User Get(int id);
        User GetByEmail(string email);
    }
}
