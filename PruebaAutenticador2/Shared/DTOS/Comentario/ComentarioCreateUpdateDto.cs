namespace PruebaAutenticador2.Shared.DTOS.Comentario
{
    public class ComentarioCreateUpdateDto
    {
        public string Contenido { get; set; } = null!;
        public string TipoObjetivo { get; set; } = null!;

        public Guid CreadorId { get; set; }
    }
}
