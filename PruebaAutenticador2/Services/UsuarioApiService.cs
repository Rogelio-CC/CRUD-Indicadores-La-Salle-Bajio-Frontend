using PruebaAutenticador2.Shared.DTOS.ListaCombos;
using PruebaAutenticador2.Shared.DTOS.Usuarios;
using PruebaAutenticador2.Classes;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class UsuarioApiService
    {
        private readonly HttpClient _http;

        public UsuarioApiService(HttpClient http)
        {
            _http = http;
        }

        /* public async Task<List<UsuarioDto>> GetAllAsync()
        {
           return await _http.GetFromJsonAsync<List<UsuarioDto>>("api/usuarios/dto") ?? new List<UsuarioDto>();
        } */

        /* public async Task<UsuarioDto?> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<UsuarioDto>($"api/usuarios/dto/{id}");
        } */

        /* public async Task<bool> CreateAsync(UsuarioCreateUpdateDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/usuarios/dto", dto);
            return response.IsSuccessStatusCode;
        } */

        /* public async Task<bool> UpdateAsync(Guid id, UsuarioCreateUpdateDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/usuarios/dto/{id}", dto);
            return response.IsSuccessStatusCode;
        } */

        /* public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/usuarios/{id}");
            return response.IsSuccessStatusCode;
        } */

        /* public async Task<UsuarioDto?> GetByEmailAsync(string email)
        {
            return await _http.GetFromJsonAsync<UsuarioDto>($"api/usuarios/email/{email}");
        } */

        public async Task<ApiResponse<List<UsuarioDto>>> GetAllAsync()
        {
            var result = new ApiResponse<List<UsuarioDto>>();

            try
            {
                var response = await _http.GetAsync("api/usuarios/dto");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<UsuarioDto>>();
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

        public async Task<ApiResponse<UsuarioDto?>> GetByIdAsync(Guid id)
        {
            var result = new ApiResponse<UsuarioDto?>();

            try
            {
                var response = await _http.GetAsync($"api/usuarios/dto/{id}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<UsuarioDto>();
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

        public async Task<ApiResponse<bool>> CreateAsync(UsuarioCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/usuarios/dto", dto);

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

        public async Task<ApiResponse<bool>> UpdateAsync(Guid id, UsuarioCreateUpdateDto dto)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var response = await _http.PutAsJsonAsync($"api/usuarios/dto/{id}", dto);

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
                var response = await _http.DeleteAsync($"api/usuarios/{id}");

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

        public async Task<ApiResponse<UsuarioDto?>> GetByEmailAsync(string email)
        {
            var result = new ApiResponse<UsuarioDto?>();

            try
            {
                var response = await _http.GetAsync($"api/usuarios/dto/email/{email}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<UsuarioDto>();
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

        public async Task<List<UsuarioComboDTO>> GetComboAsync()
        {
            return await _http.GetFromJsonAsync<List<UsuarioComboDTO>>("api/usuarios/combo")
                   ?? new();
        }


    }
}
