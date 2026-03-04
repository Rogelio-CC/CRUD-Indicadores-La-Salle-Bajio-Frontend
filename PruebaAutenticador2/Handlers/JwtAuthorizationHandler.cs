using Microsoft.AspNetCore.Components;
using PruebaAutenticador2.Services;
using System.Net;
using System.Net.Http.Headers;


namespace PruebaAutenticador2.Handlers
{
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        private readonly AuthStateService _authState;

        public JwtAuthorizationHandler(AuthStateService authState)
        {
            _authState = authState;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _authState.JwtToken;

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }

}
