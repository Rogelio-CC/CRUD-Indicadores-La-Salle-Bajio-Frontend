namespace PruebaAutenticador2.Shared.DTOS.Indicador
{
    // DTO para crear o actualizar un indicador.
    public class IndicadorCreateUpdateDto
    {
        // Descripción del indicador.
        public string DescripcionIndicador { get; set; } = null!;

        // Estándar (porcentaje) del indicador.
        public decimal Estandar { get; set; }

        // Frecuencia de control (cada cuando se administra el indicador: mensual, semanal, diario, anual).
        public string FrecuenciaControl { get; set; } = null!;

        // Cantidad de evidencias requeridas.
        public int CantidadEvidencias { get; set; }

        // Indica si el indicador está completado.
        public bool IndicadorCompletado { get; set; }

        // Acción correctiva opcional.
        public string? AccionCorrectiva { get; set; }

        // Fecha en la que se emite el indicador.
        public DateTime FechaEmision { get; set; }

        // Fecha en la que se cumplió el indicador.
        public DateTimeOffset? FechaCumplimiento { get; set; }

        // Identificador de la directriz a la que aplica el indicador.
        public Guid DirectrizId { get; set; }

        // Identificador del grupo a la que aplica el indicador.
        public Guid GrupoId { get; set; }

        // Identificador del usuario que creó el indicador.
        public Guid CreadorId { get; set; }

        // Identificador opcional del usuario responsable de la acción correctiva.
        public Guid? ResponsableAccionCorrectivaId { get; set; }

        // Identificador del período escolar a la que aplica el indicador.
        public Guid PeriodoId { get; set; }

        // Identificador de la carrera a la que pertenece el indicador.
        public Guid CarreraId { get; set; }
    }
}
