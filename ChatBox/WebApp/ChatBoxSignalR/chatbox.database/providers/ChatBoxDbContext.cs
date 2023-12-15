using chatbox.core.datatbases;
using Microsoft.EntityFrameworkCore;

namespace chatbox.core.providers
{
    public class ChatBoxDbContext : DbContext
    {
        public ChatBoxDbContext(DbContextOptions<ChatBoxDbContext> options)
               : base(options)
        {

        }

        public DbSet<sys_user_db>? sys_users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
