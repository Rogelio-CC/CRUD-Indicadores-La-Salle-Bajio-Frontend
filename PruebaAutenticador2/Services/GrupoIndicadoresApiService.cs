using PruebaAutenticador2.Classes;
using PruebaAutenticador2.Shared.DTOS.ListaCombos;
using PruebaAutenticador2.Classes;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class GrupoIndicadoresApiService
    {
        private readonly HttpClient _http;

        public GrupoIndicadoresApiService(HttpClient http)
        {
            _http = http;
        }

        /* public async Task<List<GroupOfIndicators>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<GroupOfIndicators>>("api/grupo-indicadores")
           ?? new List<GroupOfIndicators>();
        } */

        /* public async Task<GroupOfIndicators?> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<GroupOfIndicators>($"api/grupo-indicadores/{id}");
        } */

        /* public async Task CreateAsync(GroupOfIndicators goi)
        {
            await _http.PostAsJsonAsync("api/grupo-indicadores", goi);
        } */

        /* public async Task UpdateAsync(Guid id, GroupOfIndicators goi)
        {
            await _http.PutAsJsonAsync($"api/grupo-indicadores/{id}", goi);
        } */

        /* public async Task DeleteAsync(Guid id)
        {
            await _http.DeleteAsync($"api/grupo-indicadores/{id}");
        } */

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

        public async Task<List<GrupoIndicadoresComboDTO>> GetComboAsync()
        {
            return await _http.GetFromJsonAsync<List<GrupoIndicadoresComboDTO>>("api/grupo-indicadores/combo")
                   ?? new();
        }
    }
}
