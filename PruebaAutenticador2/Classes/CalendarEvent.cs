namespace PruebaAutenticador2.Classes
{
    // Representa un evento mostrado en el calendario del sistema.
    public class CalendarEvent
    {
        // Identificador único del evento.
        public Guid Id { get; set; }

        // Título del evento.
        public string Titulo { get; set; } = null!;

        // Fecha de inicio o comienzo del evento.
        public DateTime FechaInicio { get; set; }

        // Fecha de finalización del evento.
        public DateTime FechaFin { get; set; }

        // Tipo de evento (por ejemplo: entrega, revisión, cierre).
        public string TipoEvento { get; set; } = null!;

        // Color opcional para la identificación del evento.
        public string? Color { get; set; } = null;

        // Método de la clase que ayuda a obttener los eventos que ocurren en un día en específico.
        public bool IsOnDate(DateTime date)
        {
           return date.Date >= FechaInicio.Date && date.Date <= FechaFin.Date;
        }


    }

}
