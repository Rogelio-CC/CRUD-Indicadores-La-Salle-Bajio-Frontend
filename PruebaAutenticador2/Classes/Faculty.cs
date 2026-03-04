namespace PruebaAutenticador2.Classes
{
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
        //public Guid UserId { get; set; }
        //public User? ResponsiblePlan { get; set; }
        //public User? Evaluator { get; set; }
    }
}
