using System.Net;

namespace PruebaAutenticador2.Classes
{
    // Clase genérica para representar la respuesta de una API
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T? Data { get; set; }
    }
}

