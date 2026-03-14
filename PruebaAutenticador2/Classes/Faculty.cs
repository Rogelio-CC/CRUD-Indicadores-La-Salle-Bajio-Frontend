namespace PruebaAutenticador2.Classes
{
    // Atributos de la clase Facultad
    public class Faculty
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Mision { get; set; } = null!;
        public string Vision { get; set; } = null!;
        public string Slogan { get; set; } = null!;
        public string PoliticaAsociada { get; set; } = null!;
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaEdicion { get; set; }
    }
}
