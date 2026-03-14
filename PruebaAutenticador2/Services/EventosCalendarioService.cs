using PruebaAutenticador2.Classes;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class EventosCalendarioService
    {
        private readonly HttpClient _http;

        public EventosCalendarioService(HttpClient http)
        {
            _http = http;
        }

        // Método para obtener todos los eventos del calendario
        public async Task<ApiResponse<List<CalendarEvent>>> GetAllAsync()
        {
            var result = new ApiResponse<List<CalendarEvent>>();

            try
            {
                var response = await _http.GetAsync("api/eventosCalendario");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<CalendarEvent>>();
                }
            }
            catch (HttpRequestException)
            {
                result.Success = false;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;
                result.ErrorMessage = "No se pudo conectar con el servidor.";
            }
            catch (Exception)
            {
                result.Success = false;
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.ErrorMessage = "Error inesperado.";
            }


            return result;
        }
    }
}
