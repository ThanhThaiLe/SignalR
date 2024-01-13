namespace chatbox.zapp.Services
{
    public class ChatService
    {
        /// <summary>
        /// Key, Value eg: { {"Join","123456@#"},{"Join","123456@#"},{"Join","123456@#"}}
        /// </summary>
        public static readonly Dictionary<string, string> Users = new Dictionary<string, string>();
        public bool AddUserToList(string userToAdd)
        {
            lock (Users)
            {
                foreach (var item in Users)
                {
                    if (item.Key.ToLower() == userToAdd.ToLower())
                    {
                        return false;
                    }
                }
                Users.Add(userToAdd, null);
                return true;
            }
        }
        public void AddUserConnectionId(string user, string connectionId)
        {
            lock (Users)
            {
                if (Users.ContainsKey(user))
                {
                    Users[user] = connectionId;
                }
            }
        }
        public string GetUserByConnectionId(string connectionId)
        {
            lock (Users)
            {
                return Users.Where(q => q.Value == connectionId).Select(q => q.Key).FirstOrDefault();
            }
        }
        public string GetConnectionByUser(string user)
        {
            lock (Users)
            {
                return Users.Where(q => q.Key == user).Select(q => q.Value).FirstOrDefault();
            }
        }
        public void RemoveUserFromList(string user)
        {
            lock (Users)
            {
                Users.Remove(user);
            }
        }
        public string[] GetOnlineUser()
        {
            lock (Users)
            {
                return Users.OrderBy(q => q.Key).Select(q => q.Key).ToArray();
            }
        }
    }
}
