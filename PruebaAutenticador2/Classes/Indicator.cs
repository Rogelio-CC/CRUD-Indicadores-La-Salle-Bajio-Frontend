namespace PruebaAutenticador2.Classes
{
    // Atributos de la clase Indicador
    public class Indicator
    {
        public Guid Id { get; set; }
        public string DescripcionIndicador { get; set; } = null!;
        public decimal Estandar { get; set; }
        public string FrecuenciaControl { get; set; } = null!;
        public int CantidadEvidencias { get; set; }
        public bool IndicadorCompletado { get; set; }
        public string? AccionCorrectiva { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTimeOffset? FechaCumplimiento { get; set; }

        public Guid DirectrizId { get; set; }
        public string Directriz { get; set; } = null!;

        public Guid GrupoId { get; set; }
        public string Grupo { get; set; } = null!;

        public Guid CreadorId { get; set; }
        public string Creador { get; set; } = null!;

        public Guid? ResponsableAccionCorrectivaId { get; set; }
        public string? ResponsableAccionCorrectiva { get; set; }

        public Guid PeriodoId { get; set; }
        public string Periodo { get; set; } = null!;

        public Guid CarreraId { get; set; }
        public string Carrera { get; set; } = null!;

    }
}
