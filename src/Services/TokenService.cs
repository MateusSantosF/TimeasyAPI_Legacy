using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeasyAPI.src.Models.Core;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.src.Services
{
    public class TokenService: ITokenService
    {

        private readonly AppSettings _settings;

        public TokenService(IOptions<AppSettings> settings) {
            _settings = settings.Value;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.TokenConfiguration.SecretJwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FullName.ToString()),
                    new Claim(ClaimTypes.Role, user.AcessLevel.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(_settings.TokenConfiguration.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
