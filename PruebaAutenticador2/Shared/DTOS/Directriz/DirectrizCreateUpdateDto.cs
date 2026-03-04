namespace PruebaAutenticador2.Shared.DTOS.Directriz
{
    public class DirectrizCreateUpdateDto
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public Guid FacultadId { get; set; }
        public Guid CreadorId { get; set; }
        public Guid PeriodoId { get; set; }
    }
}
