namespace PruebaAutenticador2.Shared.DTOS.Actividad
{
    // DTO para representar la información de una actividad
    public class ActividadDto
    {
        public Guid Id { get; set; }
        public string DescripcionActividad { get; set; } = null!;
        public decimal CantidadLograda { get; set; } = 0;
        public DateTime FechaEmision { get; set; }

        public DateTimeOffset? FechaCumplimiento { get; set; }
        public bool ActividadCumplida { get; set; }

        public Guid EstrategiaId { get; set; }
        public string Estrategia { get; set; } = null!;

        public Guid CreadorId { get; set; }
        public string Creador { get; set; } = null!;

        public Guid PeriodoId { get; set; }
        public string Periodo { get; set; } = null!;

        public Guid CarreraId { get; set; }
        public string Carrera { get; set; } = null!;
    }
}
