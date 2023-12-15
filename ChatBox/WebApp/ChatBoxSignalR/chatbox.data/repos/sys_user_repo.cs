using chatbox.core.providers;
using chatbox.data.models;
using Microsoft.EntityFrameworkCore;

namespace chatbox.data.repos
{
    public class sys_user_repo
    {
        public ChatBoxDbContext _context;
        public sys_user_repo(ChatBoxDbContext context)
        {
            _context = context;
        }
        public async Task<sys_user_model> getElementById(long id)
        {
            var result = await _context.sys_users.Where(q => q.id == id).Select(q => new sys_user_model()
            {
                db = q,
            }).SingleOrDefaultAsync();
            return result;
        }
    }
}
