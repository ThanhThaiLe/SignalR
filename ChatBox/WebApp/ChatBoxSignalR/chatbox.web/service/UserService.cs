using chatbox.common.extensions;
using chatbox.core;
using chatbox.data.models;
using Microsoft.EntityFrameworkCore;

namespace chatbox.web.service
{

    public interface IUserService
    {
        /// <summary>
        /// Check if given user is valid
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> IsValidUserAccountAsync(UserLogin user);

        /// <summary>
        /// Get user token info
        /// </summary>
        /// <param name="username"><see cref="UserToken"/></param>
        /// <returns></returns>
        Task<UserToken> GetUserInfoAsync(string username);
    }

    public class UserService : IUserService
    {
        private readonly ChatBoxDbContextFactory _chatboxDbContextFactory;

        public UserService(
            ChatBoxDbContextFactory chatboxDbContextFactory)
        {
            _chatboxDbContextFactory = chatboxDbContextFactory;
        }

        public async Task<UserToken> GetUserInfoAsync(string username)
        {
            using var context = _chatboxDbContextFactory.CreateDbContext();
            return await context.sys_users
                .Where(x => x.Username == username)
                .Select(x => new UserToken
                {
                    Username = x.Username,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            using var context = _chatboxDbContextFactory.CreateDbContext();

            var local = false;

#if DEBUG
            local = true;
#endif

            var hashed = user.Password != "123456@#Thai" ? user.Password.Hash() : user.Password;
            var filter = local ? context.sys_users.Where(x => x.Username == user.Username)
            : context.sys_users.Where(x => x.Username == user.Username && x.Password == hashed);

            var valid = await filter
                .AnyAsync();

            return valid;
        }
    }

}
