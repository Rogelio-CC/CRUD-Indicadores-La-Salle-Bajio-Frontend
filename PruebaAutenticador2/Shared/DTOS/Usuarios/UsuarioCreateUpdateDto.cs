namespace PruebaAutenticador2.Shared.DTOS.Usuarios
{
    // DTO para crear o actualizar un usuario.
    public class UsuarioCreateUpdateDto
    {
        // Nombre del usuario.
        public string NombreUsuario { get; set; } = null!;

        // Correo institucional del usuario.
        public string CorreoInstitucional { get; set; } = null!;

        // Tipo de usuario.
        public string TipoUsuario { get; set; } = null!;

        // Identificador del rol a la que pertenece el usuario.
        public Guid RolId { get; set; }

        // Identificador de la facultad a la que pertenece el usuario.
        public Guid FacultadId { get; set; }

        // Identificador de la carrera a la que pertenece el usuario.
        public Guid CarreraId { get; set; }

    }
}
