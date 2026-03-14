namespace PruebaAutenticador2.Shared.DTOS.Actividad
{
    // DTO (Data Transfer Object) para crear o actualizar una actividad
    public class ActividadCreateUpdateDto
    {
        public Guid Id { get; set; }
        public string DescripcionActividad { get; set; } = null!;
        public decimal CantidadLograda { get; set; } = 0;
        public DateTime FechaEmision { get; set; }

        public DateTimeOffset? FechaCumplimiento { get; set; }
        public bool ActividadCumplida { get; set; }

        public Guid EstrategiaId { get; set; }

        public Guid CreadorId { get; set; }

        public Guid PeriodoId { get; set; }

        public Guid CarreraId { get; set; }
    }
}
