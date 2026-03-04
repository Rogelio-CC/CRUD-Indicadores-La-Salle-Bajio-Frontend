using PruebaAutenticador2.Classes;
using PruebaAutenticador2.Shared.DTOS.ListaCombos;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class PeriodoEscolarApiService
    {
        private readonly HttpClient _http;

        public PeriodoEscolarApiService(HttpClient http)
        {
            _http = http;
        }

        /* public async Task<List<SchoolTerm>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<SchoolTerm>>("api/periodos-escolares")
           ?? new List<SchoolTerm>();
        } */

        /* public async Task<SchoolTerm?> GetByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<SchoolTerm>($"api/periodos-escolares/{id}");
        } */

        /* public async Task CreateAsync(SchoolTerm schoolTerm)
        {
            await _http.PostAsJsonAsync("api/periodos-escolares", schoolTerm);
        } */

        /* public async Task UpdateAsync(Guid id, SchoolTerm schoolTerm)
        {
            await _http.PutAsJsonAsync($"api/periodos-escolares/{id}", schoolTerm);
        } */

       /*  public async Task DeleteAsync(Guid id)
        {
            await _http.DeleteAsync($"api/periodos-escolares/{id}");
        } */

        public async Task<ApiResponse<List<SchoolTerm>>> GetAllAsync()
        {
            var result = new ApiResponse<List<SchoolTerm>>();

            try
            {
                var response = await _http.GetAsync("api/periodos-escolares");
                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<SchoolTerm>>();
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

        public async Task<ApiResponse<SchoolTerm?>> GetByIdAsync(Guid id)
        {
            var result = new ApiResponse<SchoolTerm?>();

            try
            {
                var response = await _http.GetAsync($"api/periodos-escolares/{id}");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<SchoolTerm>();
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

        public async Task<ApiResponse<bool>> CreateAsync(SchoolTerm schoolTerm)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/periodos-escolares", schoolTerm);

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

        public async Task<ApiResponse<bool>> UpdateAsync(Guid id, SchoolTerm schoolTerm)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var response = await _http.PutAsJsonAsync($"api/periodos-escolares/{id}", schoolTerm);

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
                var response = await _http.DeleteAsync($"api/periodos-escolares/{id}");

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

        public async Task<List<PeriodoEscolarComboDTO>> GetComboAsync()
        {
            return await _http.GetFromJsonAsync<List<PeriodoEscolarComboDTO>>("api/periodos-escolares/combo")
                   ?? new();
        }
    }
}
