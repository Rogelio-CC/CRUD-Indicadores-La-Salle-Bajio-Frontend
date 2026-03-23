using System.Net;

namespace PruebaAutenticador2.Classes
{
    // Clase genérica para representar la respuesta de una API
    public class ApiResponse<T>
    {
        // Indica si fue exitosa la solicitud.
        public bool Success { get; set; }

        // Contiene el mensaje de error en caso de que la solicitud no fuera existosa.
        public string? ErrorMessage { get; set; }

        // Contiene el estado de la solicitud (Ejemplo: error 500).
        public HttpStatusCode StatusCode { get; set; }

        // Contiene toda la información de la entidad en caso de que la solicitud fuera exitosa.
        public T? Data { get; set; }
    }
}

