// Importaciones necesarias para el funcionamiento del servicio
using PruebaAutenticador2.Shared.DTOS.Auth;

namespace PruebaAutenticador2.Services
{
    // Servicio para interactuar con la API de autenticación
    public class AuthApiService
    {
        // Inyección de HttpClient para realizar las solicitudes HTTP
        private readonly HttpClient _http;

        // Constructor que recibe el HttpClient a través de la inyección de dependencias
        public AuthApiService(HttpClient http)
        {
            _http = http;
        }

        // Método para realizar el login del usuario utilizando su correo electrónico
        public async Task<LoginResponseDto?> LoginAsync(string email)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/auth/login", new LoginRequestDto 
                { 
                    Email = email 
                }); // Se envía una solicitud POST a la API de autenticación con el correo electrónico del usuario

                if (!response.IsSuccessStatusCode) return null; // Si la respuesta no es exitosa, se retorna null

                return await response.Content.ReadFromJsonAsync<LoginResponseDto>(); // Si la respuesta es exitosa, se lee el contenido de la respuesta y se deserializa en un objeto LoginResponseDto que contiene el token de autenticación
            }
            // Si ocurre una excepción durante la solicitud HTTP, se captura y se retorna null
            catch (HttpRequestException) {

                return null;
            }
            
        }
    }

}
