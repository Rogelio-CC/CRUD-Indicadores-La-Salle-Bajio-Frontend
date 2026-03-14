namespace PruebaAutenticador2.Shared.DTOS.Carrera
{
    // DTO para crear o actualizar una carrera
    public class CarreraCreateUpdateDto
    {
        public Guid Id { get; set; }
        public string NombreCarrera { get; set; } = null!;
        public Guid FacultadId { get; set; }
    }
}
