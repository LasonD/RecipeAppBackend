using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Identity
{
    public interface IJwtGenerator
    {
        JwtSecurityToken GenerateToken(AppIdentityUser user);
        string FlattenToken(JwtSecurityToken jwtSecurityToken);
    }

    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtSecurityToken GenerateToken(AppIdentityUser user)
        {
            var jwtSettings = new JwtSettings(_configuration);

            var claims = new Claim[]
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.DomainUser.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                jwtSettings.ValidIssuer, 
                jwtSettings.ValidAudience,
                claims,
                expires: jwtSettings.ExpiresIn, 
                signingCredentials: jwtSettings.SigningCredentials);

            return token;
        }

        public string FlattenToken(JwtSecurityToken securityToken)
        {
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
