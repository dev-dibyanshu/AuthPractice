using AuthPractice.DTOs;

namespace AuthPractice.Services
{
    public interface IAuthService 
    {
        public Task<LoginResponse?> LoginAsync(LoginRequest request);
        public Task<bool> RegisterAsync(SignupRequest request);
    }
}
