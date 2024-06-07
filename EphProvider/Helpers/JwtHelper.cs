using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using EphProvider.Models;
using Microsoft.Extensions.Options;
using EphProvider.Configurations;

namespace EphProvider.Helpers
{
    public class JwtHelper
    {
        private readonly TokenConfig _tokenConfig;

        public JwtHelper(IOptions<TokenConfig> tokenConfig)
        {
            _tokenConfig = tokenConfig.Value;
        }

        public string GenerateJwtToken(User user)
        {
            if (_tokenConfig == null)
            {
                throw new ArgumentNullException(nameof(_tokenConfig), "Token configuration is null.");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role) // Add role claim here
                }),
                Expires = DateTime.UtcNow.AddMinutes(_tokenConfig.AccessTokenExpiration),
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
