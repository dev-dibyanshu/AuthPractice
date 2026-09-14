using AuthPractice.DTOs;
using AuthPractice.Models;
using AuthPractice.Repositories;
using AuthPractice.Security;

namespace AuthPractice.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public Task<bool> RegisterAsync(SignupRequest request)
        {
            var existingUser = _userRepository.GetByUsername(request.UserName);

            if(existingUser is not null)
            {
                return Task.FromResult(false);
            }

            var user = new User
            {
                Id = 1,
                UserName = request.UserName,
                Password = request.Password,
                Role = "Student"
            };

            _userRepository.Add(user);

            return Task.FromResult(true);
        }
        public Task<LoginResponse?> LoginAsync(LoginRequest request) {

            var user = _userRepository.GetByUsername(request.UserName);

            if(user is null || user.Password != request.Password)
            {
                return Task.FromResult<LoginResponse?>(null);
            }

            var token = _jwtTokenService.generateToken(user);

            return Task.FromResult<LoginResponse?>(
                new LoginResponse
                {
                    Token = token
                });
        }

    }
}
