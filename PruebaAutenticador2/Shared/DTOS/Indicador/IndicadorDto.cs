namespace PruebaAutenticador2.Shared.DTOS.Indicador
{
    // DTO para representar un indicador.
    public class IndicadorDto
    {
        // Identificador del indicador.
        public Guid Id { get; set; }

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

        // Nombre de la directriz.
        public string Directriz { get; set; } = null!;

        // Identificador del grupo a la que aplica el indicador.
        public Guid GrupoId { get; set; }

        // Nombre del grupo.
        public string Grupo { get; set; } = null!;

        // Identificador del usuario que creó el indicador.
        public Guid CreadorId { get; set; }

        // Nombre del usuario.
        public string Creador { get; set; } = null!;

        // Identificador opcional del usuario responsable de la acción correctiva.
        public Guid? ResponsableAccionCorrectivaId { get; set; }

        // Nombre del responsable (usuario).
        public string? ResponsableAccionCorrectiva { get; set; }

        // Identificador del período escolar a la que aplica el indicador.
        public Guid PeriodoId { get; set; }

        // Nombre del período escolar.
        public string Periodo { get; set; } = null!;

        // Identificador de la carrera a la que pertenece el indicador.
        public Guid CarreraId { get; set; }

        // Nombre de la carrera.
        public string Carrera { get; set; } = null!;

    }
}
