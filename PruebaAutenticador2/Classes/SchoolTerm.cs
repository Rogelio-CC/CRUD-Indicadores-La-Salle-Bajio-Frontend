namespace PruebaAutenticador2.Classes
{
    // Representa un período escolar utilizado para la creación de elementos como indicadores.
    public class SchoolTerm
    {
        // Identificador único del período escolar.
        public Guid Id { get; set; } = Guid.NewGuid();

        // Nombre del período escolar.
        public string Nombre { get; set; } = null!;

        // Fecha de inicio o comienzo del período escolar.
        public DateTimeOffset FechaInicio { get; set; } = DateTimeOffset.Now;

        // Fecha de finalización del período escolar.
        public DateTimeOffset FechaFin { get; set; } = DateTimeOffset.Now;
    }
}
