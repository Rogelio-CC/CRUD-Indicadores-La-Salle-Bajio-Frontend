using PruebaAutenticador2.Shared.DTOS.Directriz;
using PruebaAutenticador2.Shared.DTOS.ListaCombos;
using PruebaAutenticador2.Classes;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class DirectrizApiService
    {
        private readonly HttpClient _http;

        public DirectrizApiService(HttpClient http)
        {
            _http = http;
        }

        /* public async Task<List<DirectrizDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<DirectrizDto>>("api/directrices/dto")
                   ?? new List<DirectrizDto>();
        } */

        /* public async Task<DirectrizDto?> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<DirectrizDto>($"api/directrices/dto/{id}");
        } */

        /* public async Task<bool> CreateAsync(DirectrizCreateUpdateDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/directrices/dto", dto);
            return response.IsSuccessStatusCode;
        } */

        /* public async Task<bool> UpdateAsync(Guid id, DirectrizCreateUpdateDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/directrices/dto/{id}", dto);
            return response.IsSuccessStatusCode;
        } */
        
        /* public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/directrices/{id}");
            return response.IsSuccessStatusCode;
        } */

        public async Task<ApiResponse<List<DirectrizDto>>> GetAllAsync()
        {
            var result = new ApiResponse<List<DirectrizDto>>();

            try
            {
                var response = await _http.GetAsync("api/directrices/dto");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<DirectrizDto>>();
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

        public async Task<ApiResponse<DirectrizDto?>> GetByIdAsync(Guid id)
        {
            var result = new ApiResponse<DirectrizDto>();

            try
            {
                var response = await _http.GetAsync($"api/directrices/dto/{id}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<DirectrizDto>();
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

        public async Task<ApiResponse<bool>> CreateAsync(DirectrizCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/directrices/dto", dto);

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

        public async Task<ApiResponse<bool>> UpdateAsync(Guid id, DirectrizCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var response = await _http.PutAsJsonAsync($"api/directrices/dto/{id}", dto);

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
                var response = await _http.DeleteAsync($"api/directrices/{id}");

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

        public async Task<List<DirectrizComboDTO>> GetComboAsync()
        {
            return await _http.GetFromJsonAsync<List<DirectrizComboDTO>>("api/directrices/combo")
                   ?? new();
        }

    }
}

