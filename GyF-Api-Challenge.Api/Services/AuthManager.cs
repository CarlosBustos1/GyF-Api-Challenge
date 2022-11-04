using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GyF_Api_Challenge.Api.Services
{
    public class AuthManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser _user;
        private readonly IConfiguration _configuration;
        public AuthManager(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateAsync(string username, string password)
        {
            _user = await _userManager.FindByNameAsync(username);

            return _user != null && await _userManager.CheckPasswordAsync(_user, password);
        }

        public string CreateToken()
        {
            SigningCredentials signingCredentials = CreateSigningCredentials();

            List<Claim> claims = GenerateClaims();

            JwtSecurityToken jwtSecurityToken = GenerateToken(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials,
                claims: claims
                );
        }

        private SigningCredentials CreateSigningCredentials()
        {
            string key = _configuration["Jwt:Key"];
            return new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256);

        }

        private List<Claim> GenerateClaims()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, _user.UserName));

            return claims;
        }
    }
}
