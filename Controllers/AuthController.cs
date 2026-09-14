using Microsoft.AspNetCore.Mvc;
using AuthPractice.DTOs;
using AuthPractice.Services;

namespace AuthPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase 
    {
        private readonly IAuthService _authService;

        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(SignupRequest request)
        {
            var res = await _authService.RegisterAsync(request);
            if(res is false)
            {
                return Conflict("username already exists.");
            }

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var res = await _authService.LoginAsync(request);

            if(res is null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(res);
        }


    }
}
