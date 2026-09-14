using AuthPractice.Models;
namespace AuthPractice.Security
{
    public interface IJwtTokenService
    {
        string generateToken(User user);
            
    }
}
