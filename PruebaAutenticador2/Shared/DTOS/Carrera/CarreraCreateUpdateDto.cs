namespace PruebaAutenticador2.Shared.DTOS.Carrera
{
    // DTO utilizado para crear o actualizar una carrera.
    public class CarreraCreateUpdateDto
    {
        // Nombre de la carrera.
        public string NombreCarrera { get; set; } = null!;

        // Identificador de la facultad a la que pertenece.
        public Guid FacultadId { get; set; }
    }
}
