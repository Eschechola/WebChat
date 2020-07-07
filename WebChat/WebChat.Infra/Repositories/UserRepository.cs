using System.Linq;
using WebChat.Infra.Interfaces;
using WebChat.Infra.Data.Context;
using WebChat.Domain.Entities;

namespace WebChat.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ChatDataContext _context;

        public UserRepository(ChatDataContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            var user = from usr in _context.Users
                       
                       where
                            usr.Email.ToLower() == email.ToLower()

                       select usr;

            return user.FirstOrDefault();
        }


        public User GetByHash(string hash)
        {
            var user = from usr in _context.Users

                       where
                            usr.Hash.ToLower() == hash.ToLower()

                       select usr;

            return user.FirstOrDefault();
        }
    }
}
