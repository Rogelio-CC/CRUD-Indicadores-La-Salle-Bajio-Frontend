// Importaciones necesarias para el funcionamiento del servicio.
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PruebaAutenticador2.Services
{
    // Clase estática que proporciona métodos auxiliares para trabajar con tokens JWT.
    public static class JwtHelper
    {
        // Método para extraer el rol del usuario desde un token JWT.
        public static string? GetRole(string token)
        {
            var handler = new JwtSecurityTokenHandler(); // Crear un nuevo manejador de tokens JWT para leer el token.
            var jwt = handler.ReadJwtToken(token); // Leer el token JWT y obtener sus claims (reclamaciones).

            return jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value; // Buscar el claim que representa el rol del usuario (ClaimTypes.Role) y retornar su valor, o null si no se encuentra.
        }

        // Método para extraer el ID del usuario desde un token JWT.
        public static string? GetIdUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            return jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; // Buscar el claim que representa el ID del usuario (ClaimTypes.NameIdentifier) y retornar su valor, o null si no se encuentra.
        }

        // Método para verificar si un token JWT ha expirado.
        public static bool isTokenExpired(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            
            var jwt = handler.ReadJwtToken(token);

            var tokenExpired = GetExpirationDate(token); // Obtener la fecha de expiración del token utilizando el método GetExpirationDate.

            return tokenExpired <= DateTime.UtcNow; // Comparar la fecha de expiración del token con la fecha y hora actual en UTC para determinar si el token ha expirado. Si la fecha de expiración es menor o igual a la fecha actual, el token se considera expirado y se retorna true; de lo contrario, se retorna false.


        }

        // Método para obtener la fecha de expiración de un token JWT.
        public static DateTime GetExpirationDate(string token) 
        { 
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            return jwt.ValidTo; // Retornar la fecha de expiración del token, que se encuentra en la propiedad ValidTo del objeto JwtSecurityToken. Esta fecha está en formato UTC.

        }
    }
}
