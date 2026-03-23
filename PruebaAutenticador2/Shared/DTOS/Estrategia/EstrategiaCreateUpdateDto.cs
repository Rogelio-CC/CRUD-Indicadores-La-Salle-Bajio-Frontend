namespace PruebaAutenticador2.Shared.DTOS.Estrategia
{
    // DTO para crear o actualizar estrategias.
    public class EstrategiaCreateUpdateDto
    {
        // Descripción de la estrategia.
        public string DescripcionEstrategia { get; set; } = null!;

        // Fecha en que se emitió la estrategia.
        public DateTime FechaEmision { get; set; }

        // Identificador del indicador al que aplica la estrategia.
        public Guid IndicadorId { get; set; }

        // Identificador del usuario que creó la estrategia.
        public Guid CreadorId { get; set; }

        // Identificador del período escolar en el que aplica la estrategia.
        public Guid PeriodoId { get; set; }

        // Identificador de la carrera al que aplica la estrategia.
        public Guid CarreraId { get; set; }

        // Identificador del comentario vinculado.
        public Guid? ComentarioId { get; set; }
    }
}
