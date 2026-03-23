namespace PruebaAutenticador2.Shared.DTOS.Usuarios
{
    // DTO para representar un usuario.
    public class UsuarioDto
    {
        // Identificador del usuario.
        public Guid Id { get; set; }

        // Nombre del usuario.
        public string NombreUsuario { get; set; } = null!;

        // Correo institucional del usuario.
        public string CorreoInstitucional { get; set; } = null!;

        // Tipo de usuario.
        public string TipoUsuario { get; set; } = null!;

        // Identificador del rol a la que pertenece el usuario.
        public Guid RolId { get; set; }

        // Nombre del rol.
        public string Rol { get; set; } = string.Empty!;

        // Identificador de la facultad a la que pertenece el usuario.
        public Guid FacultadId { get; set; }

        // Nombre de la facultad.
        public string Facultad { get; set; } = string.Empty!;

        // Identificador de la carrera a la que pertenece el usuario.
        public Guid CarreraId { get; set; }

        // Nombre de la carrera.
        public string Carrera { get; set; } = string.Empty!;
    }
}
