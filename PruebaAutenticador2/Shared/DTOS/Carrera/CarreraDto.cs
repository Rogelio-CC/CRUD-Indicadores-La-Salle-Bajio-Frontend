namespace PruebaAutenticador2.Shared.DTOS.Carrera
{
    // DTO que representa una carrera y su facultad asociada.
    public class CarreraDto
    {
        // Identificador de la carrera.
        public Guid Id { get; set; }

        // Nombre de la carrera.
        public string NombreCarrera { get; set; } = null!;

        // Identificador de la facultad a la que pertenece.
        public Guid FacultadId { get; set; }

        // Nombre de la facultad.
        public string Facultad { get; set; } = string.Empty;
    }
}
