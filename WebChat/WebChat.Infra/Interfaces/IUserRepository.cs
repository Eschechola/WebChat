using WebChat.Domain.Entities;

namespace WebChat.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email);
        User GetByHash(string hash);
    }
}
