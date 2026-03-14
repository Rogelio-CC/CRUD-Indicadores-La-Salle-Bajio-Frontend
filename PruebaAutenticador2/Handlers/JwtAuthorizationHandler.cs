using PruebaAutenticador2.Services;
using System.Net.Http.Headers;


namespace PruebaAutenticador2.Handlers
{
    // Este handler se encarga de agregar el token JWT a las solicitudes HTTP salientes, guardando el token en el AuthStateService y luego agregándolo al encabezado de autorización de cada solicitud.
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        // Inyectamos el AuthStateService para acceder al token JWT almacenado.
        private readonly AuthStateService _authState;

        // Constructor que recibe el AuthStateService a través de la inyección de dependencias.
        public JwtAuthorizationHandler(AuthStateService authState)
        {
            _authState = authState;
        }

        // Sobrescribimos el método SendAsync para agregar el token JWT al encabezado de autorización de cada solicitud HTTP.
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _authState.JwtToken;

            // Si el token no es nulo o vacío, lo agregamos al encabezado de autorización como un token Bearer.
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }

}
