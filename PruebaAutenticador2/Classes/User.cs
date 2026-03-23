namespace PruebaAutenticador2.Classes
{
    // Representa un usuario del sistema con un rol asignado
    // dentro de una facultad y carrera.
    public class User
    {
        // Identificador único del usuario.
        public Guid Id { get; set; }

        // Nombre del usuario.
        public string NombreUsuario { get; set; } = null!;

        // Correo institucional utilizado para autenticación.
        public string CorreoInstitucional { get; set; } = null!;

        // Tipo de usuarios utilizado para la autorización (relacionado fuertemente al rol).
        public string TipoUsuario { get; set; } = null!;

        // Identificador del rol a la que aplica el usuario.
        public Guid RolId { get; set; }

        // Nombre del rol.
        public string Rol { get; set; } = string.Empty;

        // Identificador de la facultad a la que pertenece el usuario.
        public Guid FacultadId { get; set; }

        // Nombre de la facultad
        public string Facultad { get; set; } = string.Empty;

        // Identificador de la carrera a la que pertenece el usuario.
        public Guid CarreraId { get; set; }

        // Nombre de la carrera.
        public string Carrera { get; set; } = string.Empty;

    }

}

