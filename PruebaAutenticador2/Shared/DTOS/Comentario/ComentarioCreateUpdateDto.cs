namespace PruebaAutenticador2.Shared.DTOS.Comentario
{
    // DTO para crear o actualizar un comentario
    public class ComentarioCreateUpdateDto
    {
        public string Contenido { get; set; } = null!;
        public string TipoObjetivo { get; set; } = null!;

        public Guid CreadorId { get; set; }
    }
}
