namespace PruebaAutenticador2.Classes
{
    // Atributos de la clase Período Escolar
    public class SchoolTerm
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public DateTimeOffset FechaInicio { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset FechaFin { get; set; } = DateTimeOffset.Now;
    }
}
