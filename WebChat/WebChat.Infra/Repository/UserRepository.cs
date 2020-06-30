using System.Linq;
using WebChat.Infra.Entities;
using WebChat.Infra.Interfaces;
using WebChat.Infra.Data.Context;

namespace WebChat.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatDataContext _context;

        public UserRepository(ChatDataContext context)
        {
            _context = context;
        }

        public User Get(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();            
        }

        public User GetByEmail(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public User Save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
