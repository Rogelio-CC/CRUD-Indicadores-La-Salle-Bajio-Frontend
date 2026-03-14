namespace PruebaAutenticador2.Shared.DTOS.Carrera
{
    // DTO para representar la información de una carrera
    public class CarreraDto
    {
        public Guid Id { get; set; }
        public string NombreCarrera { get; set; } = null!;

        public Guid FacultadId { get; set; }
        public string Facultad { get; set; } = string.Empty;
    }
}
