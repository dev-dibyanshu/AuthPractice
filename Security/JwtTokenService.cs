using AuthPractice.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthPractice.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string generateToken(User user)
        {
            var key = _configuration["Jwt:Key"] 
                ?? throw new InvalidOperationException("JWT key is not configured.");
            var issuer = _configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("JWT issuer is not configured.");
            var audience = _configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("JWT issuer is not configured.");
            var expiresInMinutes = _configuration.GetValue<int>("Jwt:ExpiresInMinutes");

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new(ClaimTypes.Role, user.Role)
            };

            var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
