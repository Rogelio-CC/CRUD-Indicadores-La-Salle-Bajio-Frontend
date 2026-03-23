namespace PruebaAutenticador2.Classes
{
    // Representa una actividad vinculada a una estrategia, periodo escolar y usuario creador
    public class Activity
    {
        // Identificador único de la actividad.
        public Guid Id { get; set; }

        // Descripción de la tarea o acción planificada.
        public string DescripcionActividad { get; set; } = null!;

        // Valor numérico alcanzado por la actividad (por ejemplo, cantidad de evidencias).
        public decimal CantidadLograda { get; set; } = 0;

        // Fecha en la que se generó o registró la actividad.
        public DateTime FechaEmision { get; set; }

        // Fecha en la que se marcó la actividad como cumplida (opcional).
        public DateTimeOffset? FechaCumplimiento { get; set; }

        // Indica si la actividad ya fue cumplida.
        public bool ActividadCumplida { get; set; }

        // Identificador de la estrategia asociada.
        public Guid EstrategiaId { get; set; }

        // Nombre de la estrategia.
        public string Estrategia { get; set; } = null!;

        // Identificador del usuario que creó la actividad.
        public Guid CreadorId { get; set; }

        // Nombre al usuario creador.
        public string Creador { get; set; } = null!;

        // Identificador del periodo escolar en el que se realiza la actividad.
        public Guid PeriodoId { get; set; }

        // Nombre del período escolar.
        public string Periodo { get; set; } = null!;

        // Identificador de la carrera vinculada.
        public Guid CarreraId { get; set; }

        // Nombre de la carrera.
        public string Carrera { get; set; } = null!;

        // Identificador del comentario vinculado.
        public Guid? ComentarioId { get; set; }

        // Nombre del comentario.
        public string? Comentario { get; set; }
    }
}
