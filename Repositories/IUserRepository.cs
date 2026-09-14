using AuthPractice.Models;

namespace AuthPractice.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        void Add(User user);
    }
}
