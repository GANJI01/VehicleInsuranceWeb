using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationWebApi.Controllers
{
    public class AuthController : Controller
    {
        private string GenerateJWT(string userName, string role, string secretKey)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new[] {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(
                issuer: "https://www.snrao.com",
                audience: "https://www.snrao.com",
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials,
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GetToken(string userName, string role, string secretKey)
        {
            string token = GenerateJWT(userName, role, secretKey);
            return token;
        }
    }
}
