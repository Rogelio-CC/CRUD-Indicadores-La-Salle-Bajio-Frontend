namespace PruebaAutenticador2.Classes
{
    public class Major
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NombreCarrera { get; set; } = string.Empty;
        public Guid FacultadId { get; set; }
        public string Facultad { get; set; } = string.Empty;
        //public Guid FacultyId { get; set; }
        //public Faculty? Faculty { get; set; }
    }
}