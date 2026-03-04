using PruebaAutenticador2.Shared.DTOS.Estrategia;
using PruebaAutenticador2.Shared.DTOS.ListaCombos;
using PruebaAutenticador2.Classes;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class EstrategiaApiService
    {
        private readonly HttpClient _http;

        public EstrategiaApiService(HttpClient http)
        {
            _http = http;
        }

        /* public async Task<List<EstrategiaDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<EstrategiaDto>>("api/estrategias/dto")
                   ?? new List<EstrategiaDto>();
        } */

        /* public async Task<EstrategiaDto?> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<EstrategiaDto>($"api/estrategias/dto/{id}");
        } */

        /* public async Task<bool> CreateAsync(EstrategiaCreateUpdateDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/estrategias/dto", dto);
            return response.IsSuccessStatusCode;
        } */

        /* public async Task<bool> UpdateAsync(Guid id, EstrategiaCreateUpdateDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/estrategias/dto/{id}", dto);
            return response.IsSuccessStatusCode;
        } */

        /* public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/estrategias/{id}");
            return response.IsSuccessStatusCode;
        } */

        public async Task<ApiResponse<List<EstrategiaDto>>> GetAllAsync()
        {
            var result = new ApiResponse<List<EstrategiaDto>>();

            try
            {
                var response = await _http.GetAsync("api/estrategias/dto");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<EstrategiaDto>>();
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

        public async Task<ApiResponse<EstrategiaDto?>> GetByIdAsync(Guid id)
        {
            var result = new ApiResponse<EstrategiaDto>();

            try
            {
                var response = await _http.GetAsync($"api/estrategias/dto/{id}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<EstrategiaDto>();
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

        public async Task<ApiResponse<bool>> CreateAsync(EstrategiaCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/estrategias/dto", dto);

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

        public async Task<ApiResponse<bool>> UpdateAsync(Guid id, EstrategiaCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var response = await _http.PutAsJsonAsync($"api/estrategias/dto/{id}", dto);

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

        public async Task<ApiResponse<bool>> DeleteAsync(Guid id)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.DeleteAsync($"api/estrategias/{id}");

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

        public async Task<List<EstrategiaComboDTO>> GetComboAsync()
        {
            return await _http.GetFromJsonAsync<List<EstrategiaComboDTO>>("api/estrategias/combo")
                   ?? new();
        }
    }
}
