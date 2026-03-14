namespace PruebaAutenticador2.Shared.DTOS.Usuarios
{
    // DTO para crear o actualizar un usuario
    public class UsuarioCreateUpdateDto
    {
        public string NombreUsuario { get; set; } = null!;
        public string CorreoInstitucional { get; set; } = null!;
        public string TipoUsuario { get; set; } = null!;
        public Guid RolId { get; set; }
        public Guid FacultadId { get; set; }
        public Guid CarreraId { get; set; }

    }
}
