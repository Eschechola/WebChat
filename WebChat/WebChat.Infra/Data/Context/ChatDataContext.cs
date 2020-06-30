using WebChat.Infra.Entities;
using WebChat.Infra.Data.Maps;
using Microsoft.EntityFrameworkCore;

namespace WebChat.Infra.Data.Context
{
    public class ChatDataContext : DbContext
    {
        public ChatDataContext(DbContextOptions<ChatDataContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
