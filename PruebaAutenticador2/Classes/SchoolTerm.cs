namespace PruebaAutenticador2.Classes
{
    public class SchoolTerm
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public DateTimeOffset FechaInicio { get; set; }
        public DateTimeOffset FechaFin { get; set; }
    }
}
