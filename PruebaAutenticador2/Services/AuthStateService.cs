namespace PruebaAutenticador2.Services
{
    // Servicio para gestionar el estado de autenticación del usuario en la aplicación
    public class AuthStateService
    {
        // Propiedades para almacenar el token JWT, el rol del usuario y su ID
        public string? JwtToken { get; private set; }
        public string? Role { get; private set; }

        public string? IdUser { get; private set; }

        // Evento que se dispara cuando cambia el estado de autenticación, permitiendo a los componentes suscribirse a estos cambios
        public event Action? OnAuthStateChanged;

        // Método para establecer el token JWT, actualizando el estado de autenticación y notificando a los suscriptores del cambio
        public void SetToken(string token)
        {
            JwtToken = token;
            OnAuthStateChanged?.Invoke();
        }

        // Método para establecer el rol del usuario, actualizando el estado de autenticación y notificando a los suscriptores del cambio
        public void SetRole(string role)
        {
            Role = role;
            OnAuthStateChanged?.Invoke();
        }

        // Método para establecer el ID del usuario, actualizando el estado de autenticación y notificando a los suscriptores del cambio
        public void SetIdUser(string idUser)
        {
            IdUser = idUser;
            OnAuthStateChanged?.Invoke();
        }

        // Método para cerrar sesión, limpiando el token JWT, el rol y el ID del usuario, y notificando a los suscriptores del cambio de estado de autenticación
        public void Logout()
        {
            JwtToken = null;
            Role = null;
            IdUser = null;
            OnAuthStateChanged?.Invoke();
        }
    }

}
