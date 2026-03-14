namespace PruebaAutenticador2.Classes
{
    // Atributos de la Clase Directriz
    public class Guideline
    {
        public Guid Id { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public Guid FacultadId { get; set; }
        public string Facultad { get; set; } = string.Empty;

        public Guid CreadorId { get; set; }
        public string Creador { get; set; } = string.Empty;

        public Guid PeriodoId { get; set; }
        public string Periodo { get; set; } = string.Empty;
    }
}
