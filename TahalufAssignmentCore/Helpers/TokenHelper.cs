using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TahalufAssignmentCore.Helpers.Settings;

namespace TahalufAssignmentCore.Helpers
{
    public static class TokenHelper
    {
        public async static Task<string> GenerateToken(string email, string fullname)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(TokenSetting.Secret);
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("UserName",fullname),
                        new Claim("Email",email),
                        new Claim(ClaimTypes.Role,fullname)
                }),
                Expires = DateTime.Now.AddHours(TokenSetting.ValidityTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                , SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }
        public async static Task<bool> ValidateToken(string tokenString, string role)
        {
            var token = new JwtSecurityToken(jwtEncodedString: tokenString);
            var roleString = (token.Claims.First(c => c.Type == "role").Value.ToString());
            if (token.ValidTo > DateTime.UtcNow && roleString.Equals(role, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
