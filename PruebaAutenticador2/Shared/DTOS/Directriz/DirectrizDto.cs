namespace PruebaAutenticador2.Shared.DTOS.Directriz
{
    // DTO para representar la información de una directriz
    public class DirectrizDto
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
