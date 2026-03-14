namespace PruebaAutenticador2.Services
{
    // Servicio para monitorear la expiración del token JWT y manejar la expiración del token de manera automática
    public class TokenWatcherService : IDisposable
    {
        // Inyección de AuthStateService para acceder al estado de autenticación del usuario y TokenStorageService para gestionar el almacenamiento del token JWT
        private readonly AuthStateService _authStateService;
        private readonly TokenStorageService _tokenStorageService;

        // Timer para programar la verificación periódica del token JWT
        private Timer? _timer;

        // Evento que se dispara cuando el token JWT ha expirado, permitiendo a los componentes suscribirse a este evento para manejar la expiración del token de manera personalizada
        public event Action? OnTokenExpired;

        // Constructor que recibe las dependencias necesarias a través de la inyección de dependencias
        public TokenWatcherService(AuthStateService authStateService, TokenStorageService tokenStorageService)
        {
            _authStateService = authStateService;
            _tokenStorageService = tokenStorageService;
        }

        // Método para iniciar el monitoreo del token JWT, programando la verificación periódica del token cada 30 segundos utilizando un Timer
        public void Start()
        {
            if (_timer != null) return;

            _timer = new Timer(CheckToken, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
        }

        // Método para verificar si el token JWT ha expirado, obteniendo el token del estado de autenticación y utilizando una función auxiliar JwtHelper.isTokenExpired para determinar
        // si el token ha expirado. Si el token ha expirado, se elimina el token del almacenamiento, se cierra la sesión del usuario y se dispara el evento OnTokenExpired para notificar
        // a los suscriptores sobre la expiración del token.
        private async void CheckToken(object? state)
        {
            var token = _authStateService.JwtToken;

            if (string.IsNullOrEmpty(token)) return;

            if (JwtHelper.isTokenExpired(token))
            {
                await _tokenStorageService.RemoveTokenAsync();
                _authStateService.Logout();
                OnTokenExpired?.Invoke();
            }
            
        }

        // Método para detener el monitoreo del token JWT, deteniendo el Timer y liberando los recursos asociados
        public void Dispose() 
        { 
            _timer?.Dispose();
        }
    }
}
