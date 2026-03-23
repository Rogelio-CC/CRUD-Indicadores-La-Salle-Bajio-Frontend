namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de roles.
    public class RolComboDTO
    {
        // Identificador del rol.
        public Guid Id { get; set; }

        // Nombre del rol.
        public string Nombre { get; set; } = string.Empty;
    }
}
