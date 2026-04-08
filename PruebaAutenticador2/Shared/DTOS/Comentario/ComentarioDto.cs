namespace PruebaAutenticador2.Shared.DTOS.Comentario
{
    // DTO que representa un comentario del sistema.
    public class ComentarioDto
    {
        // Identificador del comentario.
        public Guid Id { get; set; }

        // Contenido textual del comentario.
        public string Contenido { get; set; } = null!;

        // Fecha en la que se realizó el comentario.
        public DateTime FechaComentario { get; set; }

        // Tipo de entidad a la que pertenece el comentario.
        public string TipoObjetivo { get; set; } = null!;

        // Identificador del usuario que creó el comentario.
        public Guid CreadorId { get; set; }

        // Nombre del usuario.
        public string Creador { get; set; } = null!;
    }
}
