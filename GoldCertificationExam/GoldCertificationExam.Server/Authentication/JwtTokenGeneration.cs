using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldCertificationExam.Server.Authentication
{

    public class JwtTokenGeneration
    {
        public static string Secret_key = null;

        public static string GenerateToken(Dictionary<string, string> payload)
        {
            var tokenHandler = new JwtSecurityTokenHandler();


            var key = Encoding.ASCII.GetBytes(Secret_key);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>();
            foreach (var item in payload)
            {
                claims.Add(new Claim(item.Key, item.Value));
            }

            var identity = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = credentials
            };

            var tokenGeneration = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(tokenGeneration);

        }
    }
}

