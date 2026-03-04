using PruebaAutenticador2.Shared.DTOS.Auth;

namespace PruebaAutenticador2.Services
{
    public class AuthApiService
    {
        private readonly HttpClient _http;

        public AuthApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LoginResponseDto?> LoginAsync(string email)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/auth/login", new LoginRequestDto 
                { 
                    Email = email 
                });

                if (!response.IsSuccessStatusCode) return null;

                return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            }
            catch (HttpRequestException) {

                return null;
            }
            
        }
    }

}
