namespace PruebaAutenticador2.Classes
{
    // Atributos de la clase Carrera
    public class Major
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NombreCarrera { get; set; } = string.Empty;
        public Guid FacultadId { get; set; }
        public string Facultad { get; set; } = string.Empty;
    }
}