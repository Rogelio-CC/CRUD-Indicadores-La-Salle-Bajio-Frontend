namespace PruebaAutenticador2.Classes
{
    // Representa un rol dentro del sistema que define los permisos
    // asignados a un usuario.
    public class Role
    {
        // Identificador único del rol.
        public Guid Id { get; set; }

        // Nombre del rol.
        public string Nombre { get; set; } = string.Empty;
    }
}
