namespace PruebaAutenticador2.Classes
{
    // Representa una carrera académica dentro de la facultad.
    public class Major
    {
        // Identificador único de la carrera.
        public Guid Id { get; set; } = Guid.NewGuid();

        // Nombre de la carrera (por ejemplo: "Ingeniería en Sistemas").
        public string NombreCarrera { get; set; } = string.Empty;

        // Identificador a la facultad a la que pertenece.
        public Guid FacultadId { get; set; }

        // Nombre de la facultad.
        public string Facultad { get; set; } = string.Empty;
    }
}