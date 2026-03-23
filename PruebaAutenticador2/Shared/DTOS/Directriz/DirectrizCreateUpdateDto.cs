namespace PruebaAutenticador2.Shared.DTOS.Directriz
{
    // DTO para crear o actualizar directrices.
    public class DirectrizCreateUpdateDto
    {
        // Descripción de la directriz.
        public string Descripcion { get; set; } = null!;

        // Identificador de la facultad a la que pertenece la directriz.
        public Guid FacultadId { get; set; }

        // Identificador del usuario que creó la directriz.
        public Guid CreadorId { get; set; }

        // Identificador del período escolar en el que aplica la directriz.
        public Guid PeriodoId { get; set; }

        // Identificador del comentario vinculado.
        public Guid? ComentarioId { get; set; }
    }
}
