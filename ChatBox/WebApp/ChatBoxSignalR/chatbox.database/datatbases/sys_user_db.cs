using chatbox.core.@base;

namespace chatbox.core.datatbases
{
    public class sys_user_db : BaseEntity, ICreatedEntity, IUpdatedEntity
    {
        public long id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UpdatedId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
