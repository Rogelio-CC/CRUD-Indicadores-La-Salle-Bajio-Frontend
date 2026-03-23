namespace PruebaAutenticador2.Classes
{
    // Representa un comentario asociado a una entidad del sistema
    // (ejemplo: actividades, estrategias o directrices).
    public class Comment
    {
        // Identificador único del comentario.
        public Guid Id { get; set; }

        // Contenido textual del comentario.
        public string Contenido { get; set; } = null!;

        // Fecha en la que se realizó el comentario.
        public DateTime FechaComentario { get; set; }

        // Tipo de entidad a la que pertenece el comentario.
        public string TipoObjetivo { get; set; } = null!;

        // Identificador de la entidad a la que pertenece el comentario.
        public Guid IdObjetivo { get; set; }

        // Identificador del usuario que creó el comentario.
        public Guid CreadorId { get; set; }

        // Nombre del usuario creador.
        public string Creador { get; set; } = null!;
    }
}
