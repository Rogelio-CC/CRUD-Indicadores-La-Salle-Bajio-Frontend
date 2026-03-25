namespace PruebaAutenticador2.Classes
{
    // Representa una facultad dentro de la institución.
    // Contiene información institucional como misión, visión y política asociada.
    public class Faculty
    {
        // Identificador único de la facultad.
        public Guid Id { get; set; }

        // Nombre de la facultad.
        public string Nombre { get; set; } = null!;

        // Misión (próposito) de la facultad.
        public string Mision { get; set; } = null!;

        // Visión (definición de objetivos a largo plazo) de la facultad.
        public string Vision { get; set; } = null!;

        // Frase o dicho muy usado en la facultad.
        public string? Slogan { get; set; }

        // Fecha en la que se emite la facultad.
        public DateTime FechaEmision { get; set; }
    }
}
