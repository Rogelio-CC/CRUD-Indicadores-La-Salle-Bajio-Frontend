namespace PruebaAutenticador2.Shared.DTOS.Auth
{
    // DTO para la respuesta de inicio de sesión, que contiene el token JWT generado
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
    }
}
