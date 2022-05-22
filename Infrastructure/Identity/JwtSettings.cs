using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity
{
    public class JwtSettings
    {
        private readonly IConfiguration _configuration;

        public JwtSettings(IConfiguration configuration) => _configuration = configuration;

        public string ValidIssuer => _configuration["Jwt:ValidIssuer"];
        public string ValidAudience => _configuration["Jwt:ValidAudience"];
        public int TimeToLiveMin => int.Parse(_configuration["Jwt:TimeToLive"]);
        public DateTime ExpiresIn => DateTime.UtcNow.AddMinutes(TimeToLiveMin);
        public SymmetricSecurityKey SecurityKey => new(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
        public SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    }
}
