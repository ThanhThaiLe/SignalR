using chatbox.core.datatbases;
using System.ComponentModel.DataAnnotations;

namespace chatbox.data.models
{
    public class sys_user_model
    {
        public sys_user_model()
        {
            db = new sys_user_db();
        }
        public sys_user_db db { get; set; }
    }
    public class UserToken
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + " " + LastName;

        public string Role { get; set; } = string.Empty;
    }
    public class UserLogin
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
    public class TokenSetting
    {
        public string SecurityKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpiryMinutes { get; set; }
    }
}
