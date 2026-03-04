using Microsoft.AspNetCore.Components;

namespace PruebaAutenticador2.Services
{
    public class TokenWatcherService : IDisposable
    {
        private readonly AuthStateService _authStateService;
        private Timer? _timer;
        private readonly TokenStorageService _tokenStorageService;
        public event Action? OnTokenExpired;

        public TokenWatcherService(AuthStateService authStateService, TokenStorageService tokenStorageService)
        {
            _authStateService = authStateService;
            _tokenStorageService = tokenStorageService;
        }

        public void Start()
        {
            if (_timer != null) return;

            _timer = new Timer(CheckToken, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
        }

        private async void CheckToken(object? state)
        {
            var token = _authStateService.JwtToken;

            if (string.IsNullOrEmpty(token)) return;

            if (JwtHelper.isTokenExpired(token))
            {
                //Mensaje en consola
                Console.WriteLine("TOKEN EXPIRADO");
                await _tokenStorageService.RemoveTokenAsync();
                _authStateService.Logout();
                OnTokenExpired?.Invoke();
            }
            
        }

        public void Dispose() 
        { 
            _timer?.Dispose();
        }
    }
}
