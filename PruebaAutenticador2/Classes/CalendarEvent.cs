namespace PruebaAutenticador2.Classes
{
    //Atributo de la clase que representa un evento en el calendario (CalendarEvent)
    public class CalendarEvent
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string TipoEvento { get; set; } = null!;
        public string? Color { get; set; } = null;

        public bool IsOnDate(DateTime date)
        {
           return date.Date >= FechaInicio.Date && date.Date <= FechaFin.Date;
        }


    }

}
