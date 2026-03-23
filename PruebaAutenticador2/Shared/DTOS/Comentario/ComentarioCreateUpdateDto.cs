namespace PruebaAutenticador2.Shared.DTOS.Comentario
{
    // DTO para crear o actualizar comentarios.
    public class ComentarioCreateUpdateDto
    {
        // Contenido textual del comentario.
        public string Contenido { get; set; } = null!;

        // Tipo de entidad a la que pertenece el comentario.
        public string TipoObjetivo { get; set; } = null!;

        // Identificador del usuario que creó el comentario.
        public Guid CreadorId { get; set; }
    }
}
