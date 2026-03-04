using Blazorise;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using PruebaAutenticador2.Classes;
using PruebaAutenticador2.Shared.DTOS.Directriz;
using PruebaAutenticador2.Shared.DTOS.Evidencia;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class EvidenciaApiService
    {
        private readonly HttpClient _http;

        public EvidenciaApiService(HttpClient http)
        {
            _http = http;
        }

        /* public async Task<List<EvidenciaDto>> GetAllAsync(Guid indicadorId)
        {
            return await _http.GetFromJsonAsync<List<EvidenciaDto>>($"api/indicadores/{indicadorId}/evidencias")
                   ?? new List<EvidenciaDto>();
        } */

         /* public async Task<bool> UploadAsync(Guid indicadorId, IFileEntry file)
        {
            using var stream = file.OpenReadStream(file.Size);
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stream), "file", file.Name);

            var response = await _http.PostAsync($"api/indicadores/{indicadorId}/evidencias", content);

            return response.IsSuccessStatusCode;
        } */

        /* public async Task<bool> DeleteAsync(Guid indicadorId, Guid evidenciaId)
        {
            var response = await _http.DeleteAsync($"api/indicadores/{indicadorId}/evidencias/{evidenciaId}");

            return response.IsSuccessStatusCode;
        } */

        /* public async Task<byte[]> DownloadAsync(Guid indicadorId, Guid evidenciaId)
        {
            return await _http.GetByteArrayAsync($"api/indicadores/{indicadorId}/evidencias/{evidenciaId}/download");
        } */

        public async Task<ApiResponse<List<EvidenciaDto>>> GetAllAsync(Guid indicadorId)
        {
            var result = new ApiResponse<List<EvidenciaDto>>();

            try
            {
                var response = await _http.GetAsync($"api/indicadores/{indicadorId}/evidencias");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<EvidenciaDto>>();
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

        public async Task<ApiResponse<bool>> UploadAsync(Guid indicadorId, IFileEntry file)
        {

            var result = new ApiResponse<bool>();

            try
            {
                using var stream = file.OpenReadStream(file.Size);
                using var content = new MultipartFormDataContent();
                content.Add(new StreamContent(stream), "file", file.Name);

                var response = await _http.PostAsync($"api/indicadores/{indicadorId}/evidencias", content);

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

        public async Task<ApiResponse<bool>> DeleteAsync(Guid indicadorId, Guid evidenciaId)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.DeleteAsync($"api/indicadores/{indicadorId}/evidencias/{evidenciaId}");

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

        public async Task<byte[]> DownloadAsync(Guid indicadorId, Guid evidenciaId)
        {
            return await _http.GetByteArrayAsync($"api/indicadores/{indicadorId}/evidencias/{evidenciaId}/download");
        }



    }
}
