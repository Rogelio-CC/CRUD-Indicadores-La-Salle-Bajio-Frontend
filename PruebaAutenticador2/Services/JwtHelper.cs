using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PruebaAutenticador2.Services
{
    public static class JwtHelper
    {
        public static string? GetRole(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            return jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        }

        public static string? GetIdUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            return jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public static bool isTokenExpired(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            
            var jwt = handler.ReadJwtToken(token);

            var tokenExpired = GetExpirationDate(token); // ya viene en DateTime y en UTC.

            return tokenExpired <= DateTime.UtcNow;


        }

        public static DateTime GetExpirationDate(string token) 
        { 
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            return jwt.ValidTo;

        }
    }
}
