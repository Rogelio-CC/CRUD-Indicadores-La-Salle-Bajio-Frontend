using PruebaAutenticador2.Shared.DTOS.Indicador;
using PruebaAutenticador2.Shared.DTOS.ListaCombos;
using PruebaAutenticador2.Classes;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class IndicadorApiService
    {
        private readonly HttpClient _http;

        public IndicadorApiService(HttpClient http)
        {
            _http = http;
        }

        /* public async Task<List<IndicadorDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<IndicadorDto>>("api/indicadores/dto")
                   ?? new List<IndicadorDto>();
        } */

        /* public async Task<IndicadorDto?> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<IndicadorDto>($"api/indicadores/dto/{id}");
        } */

        /* public async Task<IndicadorDto?> CreateAsync(IndicadorCreateUpdateDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/indicadores/dto", dto);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<IndicadorDto>();
        } */

        /* public async Task<bool> UpdateAsync(Guid id, IndicadorCreateUpdateDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/indicadores/dto/{id}", dto);
            return response.IsSuccessStatusCode;
        } */

        /* public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/indicadores/{id}");
            return response.IsSuccessStatusCode;
        } */

        public async Task<ApiResponse<List<IndicadorDto>>> GetAllAsync()
        {
            var result = new ApiResponse<List<IndicadorDto>>();

            try
            {
                var response = await _http.GetAsync("api/indicadores/dto");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<IndicadorDto>>();
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

        public async Task<ApiResponse<IndicadorDto?>> GetByIdAsync(Guid id)
        {
            var result = new ApiResponse<IndicadorDto?>();

            try
            {
                var response = await _http.GetAsync($"api/indicadores/dto/{id}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<IndicadorDto>();
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

        public async Task<ApiResponse<IndicadorDto>> CreateAsync(IndicadorCreateUpdateDto dto)
        {
            var result = new ApiResponse<IndicadorDto>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/indicadores/dto", dto);

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<IndicadorDto>();
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

        public async Task<ApiResponse<bool>> UpdateAsync(Guid id, IndicadorCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var response = await _http.PutAsJsonAsync($"api/indicadores/dto/{id}", dto);

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
                var response = await _http.DeleteAsync($"api/indicadores/{id}");

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

        public async Task<List<IndicadorComboDTO>> GetComboAsync()
        {
            return await _http.GetFromJsonAsync<List<IndicadorComboDTO>>("api/indicadores/combo")
                   ?? new();
        }
    }
}
