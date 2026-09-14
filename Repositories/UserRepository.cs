using AuthPractice.Models;

namespace AuthPractice.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new() {
            new User
            {
                Id = 1,
                UserName = "Admin",
                Password = "Admin",
                Role = "Admin"
            }
            };
        public User? GetByUsername(string username)
        {
            return _users.FirstOrDefault(
                user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                );
        }
        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}
