using AuthPractice.Models;
using AuthPractice.Security;
namespace AuthPractice.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly List<User> _users = new();

        public UserRepository(IPasswordHasher passwordHasher)
        {
            _users = new List<User>
                {
                    new User
                    {
                        Id = 1,
                        UserName = "admin",
                        Password = passwordHasher.HashPassword("admin123"),
                        Role = "Admin"
                    }
                };
        }
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
