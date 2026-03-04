using Microsoft.JSInterop;

namespace PruebaAutenticador2.Services
{
    public class TokenStorageService
    {
        private readonly IJSRuntime _js;

        public TokenStorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<string?> GetTokenAsync()
            => await _js.InvokeAsync<string>("localStorage.getItem", "jwt-token");

        public async Task SetTokenAsync(string token)
            => await _js.InvokeVoidAsync("localStorage.setItem", "jwt-token", token);

        public async Task RemoveTokenAsync()
            => await _js.InvokeVoidAsync("localStorage.removeItem", "jwt-token");
    }

}
