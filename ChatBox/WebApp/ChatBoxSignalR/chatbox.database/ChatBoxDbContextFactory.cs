using chatbox.core.providers;
using Microsoft.EntityFrameworkCore;

namespace chatbox.core
{
    public interface IChatBoxDbContextFactory : IDbContextFactory<ChatBoxDbContext>
    {
    }

    public class ChatBoxDbContextFactory : IChatBoxDbContextFactory
    {
        private readonly DbContextOptions<ChatBoxDbContext> _options;
        public ChatBoxDbContextFactory(DbContextOptions<ChatBoxDbContext> options)
        {
            _options = options;
        }

        public ChatBoxDbContext CreateDbContext()
        {
            var db = new ChatBoxDbContext(_options);

            // todo: config db

            return db;
        }
    }
}
