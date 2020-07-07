
using WebChat.Infra.Data.Maps;
using Microsoft.EntityFrameworkCore;
using WebChat.Domain.Entities;

namespace WebChat.Infra.Data.Context
{
    public class ChatDataContext : DbContext
    {
        public ChatDataContext(DbContextOptions<ChatDataContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new MessageMap());
        }
    }
}
