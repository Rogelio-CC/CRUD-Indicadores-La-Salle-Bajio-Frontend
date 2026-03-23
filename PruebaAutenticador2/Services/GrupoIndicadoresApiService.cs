using PruebaAutenticador2.Classes;
using PruebaAutenticador2.Shared.DTOS.ListaCombos;
using System.Net;

namespace PruebaAutenticador2.Services
{
    // La estructura para GrupoIndicadoresApiService es la misma que ActividadApiService, por lo que solo aquí se indican los métodos.
    public class GrupoIndicadoresApiService
    {
        private readonly HttpClient _http;

        public GrupoIndicadoresApiService(HttpClient http)
        {
            _http = http;
        }

        // Método para obtener todos los grupos de indicadores.
        public async Task<ApiResponse<List<GroupOfIndicators>>> GetAllAsync()
        {
            var result = new ApiResponse<List<GroupOfIndicators>>();

            try
            {
                var response = await _http.GetAsync("api/grupo-indicadores");
                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<GroupOfIndicators>>();
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

        // Método para obtener un grupo de indicadores por su ID.
        public async Task<ApiResponse<GroupOfIndicators?>> GetByIdAsync(Guid id)
        {
            var result = new ApiResponse<GroupOfIndicators?>();

            try
            {
                var response = await _http.GetAsync($"api/grupo-indicadores/{id}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<GroupOfIndicators>();
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

            return result!;
        }

        // Método para crear un nuevo grupo de indicadores.
        public async Task<ApiResponse<bool>> CreateAsync(GroupOfIndicators goi)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/grupo-indicadores", goi);

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

        // Método para actualizar un grupo de indicadores existente.
        public async Task<ApiResponse<bool>> UpdateAsync(Guid id, GroupOfIndicators goi)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var response = await _http.PutAsJsonAsync($"api/grupo-indicadores/{id}", goi);

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

        // Método para eliminar un grupo de indicadores por su ID.
        public async Task<ApiResponse<bool>> DeleteAsync(Guid id)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.DeleteAsync($"api/grupo-indicadores/{id}");

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

        // Método para obtener una lista de grupos de indicadores en formato de combo (ID y nombre) para su uso en interfaces.
        public async Task<List<GrupoIndicadoresComboDTO>> GetComboAsync()
        {
            return await _http.GetFromJsonAsync<List<GrupoIndicadoresComboDTO>>("api/grupo-indicadores/combo")
                   ?? new();
        }
    }
}
