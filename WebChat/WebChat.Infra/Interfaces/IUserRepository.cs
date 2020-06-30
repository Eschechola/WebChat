using WebChat.Infra.Entities;

namespace WebChat.Infra.Interfaces
{
    public interface IUserRepository
    {
        User Save(User user);
        User Get(int id);
        User GetByEmail(string email);
    }
}
