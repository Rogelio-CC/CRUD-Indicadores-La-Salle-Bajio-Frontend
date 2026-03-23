namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de usuarios.
    public class UsuarioComboDTO
    {
        // Identificador del usuario.
        public Guid Id { get; set; }

        // Nombre del usuario.
        public string Nombre { get; set; } = string.Empty;
    }
}
