using Blazorise;
using PruebaAutenticador2.Classes;
using PruebaAutenticador2.Shared.DTOS.ArchivoPoliticas;
using System.Net;

namespace PruebaAutenticador2.Services
{
    public class ArchivoPoliticasApiService
    {
        private readonly HttpClient _http;

        public ArchivoPoliticasApiService(HttpClient http)
        {
            _http = http;
        }

        // Método para obtener el archivo de políticas asociado a una facultad específica.
        public async Task<ApiResponse<List<ArchivoPoliticasDto>>> GetByFacultyIdAsync(Guid facultadId)
        {
            var result = new ApiResponse<List<ArchivoPoliticasDto>>();

            try
            {
                var response = await _http.GetAsync($"api/facultades/{facultadId}/archivoPoliticas");

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<ArchivoPoliticasDto>>();
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

        // Método para subir el archivo de políticas asociado a una facultad específica.
        public async Task<ApiResponse<bool>> UploadAsync(Guid facultadId, IFileEntry file)
        {

            var result = new ApiResponse<bool>();

            try
            {
                // Se crea un Stream a partir del archivo seleccionado por el usuario y se prepara el contenido para la solicitud HTTP utilizando MultipartFormDataContent,
                // que es necesario para enviar archivos a través de HTTP.
                using var stream = file.OpenReadStream(file.Size);
                using var content = new MultipartFormDataContent();
                content.Add(new StreamContent(stream), "file", file.Name);

                var response = await _http.PostAsync($"api/facultades/{facultadId}/archivoPoliticas", content);

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

        // Método para eliminar el archivo de políticas asociado a una facultad específica.
        public async Task<ApiResponse<bool>> DeleteAsync(Guid facultadId, Guid archivoPoliticasId)
        {
            var result = new ApiResponse<bool>();

            try
            {
                var response = await _http.DeleteAsync($"api/facultades/{facultadId}/archivoPoliticas/{archivoPoliticasId}");

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

        // Método para descargar el archivo de políticas asociado a una facultad específica, que retorna el contenido del archivo como un arreglo de bytes.
        public async Task<byte[]> DownloadAsync(Guid facultadId, Guid archivoPoliticasId)
        {
            return await _http.GetByteArrayAsync($"api/facultades/{facultadId}/archivoPoliticas/{archivoPoliticasId}/download");
        }
    }
}
