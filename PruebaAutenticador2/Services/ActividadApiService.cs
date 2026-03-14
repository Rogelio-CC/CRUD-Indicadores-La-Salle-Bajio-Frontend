// Importaciones necesarias para el funcionamiento del servicio
using PruebaAutenticador2.Classes;
using PruebaAutenticador2.Shared.DTOS.Actividad;
using System.Net;

namespace PruebaAutenticador2.Services
{
    // Servicio para interactuar con la API de Actividades
    public class ActividadApiService
    {
        // Inyección de HttpClient para realizar las solicitudes HTTP
        private readonly HttpClient _http;

        // Constructor que recibe el HttpClient a través de la inyección de dependencias
        public ActividadApiService(HttpClient http)
        {
            _http = http;
        }

        // Método para obtener todas las actividades
        public async Task<ApiResponse<List<ActividadDto>>> GetAllAsync()
        {
            // Inicialización de la respuesta genérica de tipo lista de ActividadDto
            var result = new ApiResponse<List<ActividadDto>>();

            try
            {
                var response = await _http.GetAsync("api/actividades/dto"); // Realiza una solicitud GET a la API para obtener todas las actividades

                result.StatusCode = response.StatusCode; // Se asigna a la variable con respuesta génerica el código de estado a la propiedad StatusCode del resultado

                // Si la respuesta es exitosa, se asigna el resultado a la propiedad Data del resultado genérico y se marca como éxito
                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<ActividadDto>>();
                }
            }
            // Si la respuesta no es exitosa, se marca como error y se asigna el mensaje de error a la propiedad ErrorMessage del resultado genérico
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

        // Método para obtener una actividad por su ID
        public async Task<ApiResponse<ActividadDto?>> GetByIdAsync(Guid id)
        {
            var result = new ApiResponse<ActividadDto>();

            try
            {
                var response = await _http.GetAsync($"api/actividades/dto/{id}");

                result.StatusCode = response.StatusCode;

                // Si la respuesta es exitosa, se asigna el resultado a la propiedad Data del resultado genérico y se marca como éxito
                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<ActividadDto>();
                }
                // Si la respuesta no es exitosa, se marca como error y se asigna el mensaje de error a la propiedad ErrorMessage del resultado genérico
                else
                {
                    result.Success = false;
                    result.ErrorMessage = await response.Content.ReadAsStringAsync();
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

            return result!;
        }

        // Método para crear una nueva actividad
        public async Task<ApiResponse<bool>> CreateAsync(ActividadCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/actividades/dto", dto);

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = await response.Content.ReadAsStringAsync();
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

        // Método para actualizar una actividad existente
        public async Task<ApiResponse<bool>> UpdateAsync(Guid id, ActividadCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var response = await _http.PutAsJsonAsync($"api/actividades/dto/{id}", dto);

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = await response.Content.ReadAsStringAsync();
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

        // Método para eliminar una actividad por su ID
        public async Task<ApiResponse<bool>> DeleteAsync(Guid id)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.DeleteAsync($"api/actividades/{id}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = await response.Content.ReadAsStringAsync();
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
