namespace PruebaAutenticador2.Classes
{
    // Representa una directriz estratégica definida por una facultad
    // para un periodo escolar específico.
    public class Guideline
    {
        // Identificador único de la directriz.
        public Guid Id { get; set; }

        // Descripción de la directriz estratégica.
        public string Descripcion { get; set; } = string.Empty;

        // Identificador de la facultad a la que pertenece la directriz.
        public Guid FacultadId { get; set; }

        // Nombre de la facultad.
        public string Facultad { get; set; } = string.Empty;

        // Identificador del usuario que creó la directriz.
        public Guid CreadorId { get; set; }

        // Nombre del usuario creador.
        public string Creador { get; set; } = string.Empty;

        // Identificador del período escolar a la que pertenece la directriz.
        public Guid PeriodoId { get; set; }

        // Nombre del período escolar.
        public string Periodo { get; set; } = string.Empty;

        // Identificador del comentario vinculado.
        public Guid? ComentarioId { get; set; }

        // Nombre del comentario.
        public string? Comentario { get; set; }
    }
}
