namespace PruebaAutenticador2.Shared.DTOS.Actividad
{
    // DTO utilizado para crear o actualizar una actividad.
    public class ActividadCreateUpdateDto
    {
        // Descripción de la actividad. 
        public string DescripcionActividad { get; set; } = null!;

        //  Valor númerico alcanzado por la actividad. 
        public decimal CantidadLograda { get; set; } = 0;

        //  Fecha en la que se emite la actividad. 
        public DateTime FechaEmision { get; set; }

        // Fecha en que se completó la actividad.
        public DateTimeOffset? FechaCumplimiento { get; set; }

        // Indica si la actividad ya fue cumplida.
        public bool ActividadCumplida { get; set; }

        // Identificador de la estrategia asociada. 
        public Guid EstrategiaId { get; set; }

        // Identificador del usuario que creó la actividad.
        public Guid CreadorId { get; set; }

        // Identificador del periodo escolar en el que se realiza la actividad.
        public Guid PeriodoId { get; set; }

        // Identificador de la carrera vinculada.
        public Guid CarreraId { get; set; }

        // Identificador del comentario vinculado.
        public Guid? ComentarioId { get; set; }
    }
}
