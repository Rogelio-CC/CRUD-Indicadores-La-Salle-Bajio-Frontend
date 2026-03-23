namespace PruebaAutenticador2.Shared.DTOS.Estrategia
{
    // DTO para representar una estrategia y sus relaciones.
    public class EstrategiaDto
    {
        // Identificador de la estrategia.
        public Guid Id { get; set; }

        // Descripción de la estrategia.
        public string DescripcionEstrategia { get; set; } = null!;

        // Fecha en que se emitió la estrategia.
        public DateTime FechaEmision { get; set; }

        // Identificador del indicador al que aplica la estrategia.
        public Guid IndicadorId { get; set; }

        // Nombre del indicador.
        public string Indicador { get; set; } = string.Empty;

        // Identificador del usuario que creó la estrategia.
        public Guid CreadorId { get; set; }

        // Nombre del usuario.
        public string Creador { get; set; } = string.Empty;

        // Identificador del período escolar en el que aplica la estrategia.
        public Guid PeriodoId { get; set; }

        // Nombre del período escolar.
        public string Periodo { get; set; } = string.Empty;

        // Identificador de la carrera al que aplica la estrategia.
        public Guid CarreraId { get; set; }

        // Nombre de la carrera.
        public string Carrera { get; set; } = string.Empty;

        // Identificador del comentario vinculado.
        public Guid? ComentarioId { get; set; }

        // Nombre del comentario.
        public string? Comentario { get; set; }
    }
}
