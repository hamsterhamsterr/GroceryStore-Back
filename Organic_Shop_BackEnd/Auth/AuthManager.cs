using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Organic_Shop_BackEnd.DTO;
using Organic_Shop_BackEnd.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace Organic_Shop_BackEnd.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken(string userEmail)
        {
            _user = await _userManager.FindByNameAsync(userEmail);

            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<bool> ValidateUser(string userEmail, string userPassword)
        {
            _user = await _userManager.FindByNameAsync(userEmail);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userPassword));
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var expiration = DateTime
                .Now
                .AddDays(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim("firstName", _user.FirstName),
                new Claim("lastName", _user.LastName),
                new Claim("name", _user.UserName),
                new Claim("userId", _user.Id)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("GROCERY-STORE-KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        
    }
}
