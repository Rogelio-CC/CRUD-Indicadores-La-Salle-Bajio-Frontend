namespace PruebaAutenticador2.Shared.DTOS.Indicador
{
    // DTO para crear o actualizar un indicador
    public class IndicadorCreateUpdateDto
    {
        public string DescripcionIndicador { get; set; } = null!;
        public decimal Estandar { get; set; }
        public string FrecuenciaControl { get; set; } = null!;
        public int CantidadEvidencias { get; set; }
        public bool IndicadorCompletado { get; set; }
        public string? AccionCorrectiva { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTimeOffset? FechaCumplimiento { get; set; }
        public Guid DirectrizId { get; set; }
        public Guid GrupoId { get; set; }
        public Guid CreadorId { get; set; }
        //Nuevo dato agregado por mí
        public Guid? ResponsableAccionCorrectivaId { get; set; }
        public Guid PeriodoId { get; set; }
        public Guid CarreraId { get; set; }
    }
}
