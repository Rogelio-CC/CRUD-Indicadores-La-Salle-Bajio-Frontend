namespace PruebaAutenticador2.Shared.DTOS.Actividad
{
    // DTO que representa una actividad junto con la información
    // de sus entidades relacionadas.
    public class ActividadDto
    {
        // Identificador de la actividad. 
        public Guid Id { get; set; }

        // Descripción de la actividad. 
        public string DescripcionActividad { get; set; } = null!;

        // Valor númerico alcanzado por la actividad. 
        public decimal CantidadLograda { get; set; } = 0;

        //  Fecha en la que se emite la actividad. 
        public DateTime FechaEmision { get; set; }

        // Fecha en que se completó la actividad.
        public DateTimeOffset? FechaCumplimiento { get; set; }

        // Indica si la actividad ya fue cumplida.
        public bool ActividadCumplida { get; set; }

        // Identificador de la estrategia asociada. 
        public Guid EstrategiaId { get; set; }

        // Nombre de la estrategia asociada.
        public string Estrategia { get; set; } = null!;

        // Identificador del usuario que creó la actividad.
        public Guid CreadorId { get; set; }

        // Nombre del usuario creador.
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
