namespace PruebaAutenticador2.Shared.DTOS.Auth
{
    // DTO para la solicitud de inicio de sesión a traves del correo electrónico
    public class LoginRequestDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
