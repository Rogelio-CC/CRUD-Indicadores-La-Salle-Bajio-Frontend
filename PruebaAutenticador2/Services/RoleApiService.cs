using PruebaAutenticador2.Classes;
using PruebaAutenticador2.Shared.DTOS.ListaCombos;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class RoleApiService
    {
        private readonly HttpClient _http;

        public RoleApiService(HttpClient http)
        {
            _http = http;
        }

        /* public async Task<List<Role>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Role>>("api/roles")
           ?? new List<Role>();
        } */

        /* public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<Role>($"api/roles/{id}");
        } */

        /* public async Task CreateAsync(Role role)
        {
            await _http.PostAsJsonAsync("api/roles", role);
        } */

        /* public async Task UpdateAsync(Guid id, Role role)
        {
            await _http.PutAsJsonAsync($"api/roles/{id}", role);
        } */

        /* public async Task DeleteAsync(Guid id)
        {
            await _http.DeleteAsync($"api/roles/{id}");
        } */

        public async Task<ApiResponse<List<Role>>> GetAllAsync()
        {
            var result = new ApiResponse<List<Role>>();

            try
            {
                var response = await _http.GetAsync("api/roles");
                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<Role>>();
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

        public async Task<ApiResponse<Role?>> GetByIdAsync(Guid id)
        {
            var result = new ApiResponse<Role?>();

            try
            {
                var response = await _http.GetAsync($"api/roles/{id}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<Role>();
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

        public async Task<ApiResponse<bool>> CreateAsync(Role role)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/roles", role);

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

        public async Task<ApiResponse<bool>> UpdateAsync(Guid id, Role role)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var response = await _http.PutAsJsonAsync($"api/roles/{id}", role);

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
                var response = await _http.DeleteAsync($"api/roles/{id}");

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

        public async Task<List<RolComboDTO>> GetComboAsync()
        {
            return await _http.GetFromJsonAsync<List<RolComboDTO>>("api/roles/combo")
                   ?? new();
        }
    }

}
