using System.Collections.Generic;
using WebChat.Domain.Entities;

namespace WebChat.Services.Interfaces
{
    public interface IUserService
    {
        User Save(User user);
        User Get(int id);
        IList<User> GetAll();
        User GetByEmail(string email);
        User GetByHash(string hash);
    }
}
