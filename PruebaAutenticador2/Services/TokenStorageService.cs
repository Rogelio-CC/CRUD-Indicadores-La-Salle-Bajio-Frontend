// Importaciones necesarias para el funcionamiento del servicio.
using Microsoft.JSInterop;

namespace PruebaAutenticador2.Services
{
    // Servicio para gestionar el almacenamiento del token JWT en el almacenamiento local del navegador utilizando JavaScript Interop.
    public class TokenStorageService
    {
        // Inyección de IJSRuntime para interactuar con el almacenamiento local del navegador a través de JavaScript Interop.
        private readonly IJSRuntime _js;

        // Constructor que recibe el IJSRuntime a través de la inyección de dependencias.
        public TokenStorageService(IJSRuntime js)
        {
            _js = js;
        }

        // Método para obtener el token JWT almacenado en el almacenamiento local del navegador de forma asíncrona.
        public async Task<string?> GetTokenAsync()
            => await _js.InvokeAsync<string>("localStorage.getItem", "jwt-token");

        // Método para establecer el token JWT en el almacenamiento local del navegador de forma asíncrona.
        public async Task SetTokenAsync(string token)
            => await _js.InvokeVoidAsync("localStorage.setItem", "jwt-token", token);

        // Método para eliminar el token JWT del almacenamiento local del navegador de forma asíncrona.
        public async Task RemoveTokenAsync()
            => await _js.InvokeVoidAsync("localStorage.removeItem", "jwt-token");
    }

}
