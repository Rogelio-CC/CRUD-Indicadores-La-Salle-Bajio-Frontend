using Blazorise;
using PruebaAutenticador2.Classes;
using PruebaAutenticador2.Shared.DTOS.Evidencia;
using System.Net;

namespace PruebaAutenticador2.Services
{
    // La estructura para EvidenciaApiService es la misma que ActividadApiService, por lo que solo aquí se indican los métodos.
    public class EvidenciaApiService
    {
        private readonly HttpClient _http;

        public EvidenciaApiService(HttpClient http)
        {
            _http = http;
        }

        // Método para obtener todas las evidencias asociadas a un indicador específico.
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

        // Método para subir una nueva evidencia asociada a un indicador específico.
        public async Task<ApiResponse<bool>> UploadAsync(Guid indicadorId, byte[] contenido, string nombreArchivo)
        {

            var result = new ApiResponse<bool>();

            try
            {
                // Se crea un contenido del archivo a partir de su selección hecha por el usuario y se prepara para ser enviado a la solicitud HTTP utilizando MultipartFormDataContent,
                // que es necesario para enviar archivos a través de HTTP.
                using var content = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(contenido);
                content.Add(fileContent, "file", nombreArchivo);

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

        // Método para eliminar una evidencia específica asociada a un indicador específico.
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

        // Método para descargar una evidencia específica asociada a un indicador específico, que retorna el contenido del archivo como un arreglo de bytes.
        public async Task<byte[]> DownloadAsync(Guid indicadorId, Guid evidenciaId)
        {
            return await _http.GetByteArrayAsync($"api/indicadores/{indicadorId}/evidencias/{evidenciaId}/download");
        }



    }
}
