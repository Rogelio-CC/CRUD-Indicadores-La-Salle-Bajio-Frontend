using System.Threading.Tasks;
using PruebaAutenticador2.Services;

namespace PruebaAutenticador2.Services
{
    public class AuthStateService
    {
        public string? JwtToken { get; private set; }
        public string? Role { get; private set; }

        public string? IdUser { get; private set; }

        public event Action? OnAuthStateChanged;

        public void SetToken(string token)
        {
            JwtToken = token;
            OnAuthStateChanged?.Invoke();
        }

        public void SetRole(string role)
        {
            Role = role;
            OnAuthStateChanged?.Invoke();
        }

        public void SetIdUser(string idUser)
        {
            IdUser = idUser;
            OnAuthStateChanged?.Invoke();
        }

        public void Logout()
        {
            JwtToken = null;
            Role = null;
            IdUser = null;
            OnAuthStateChanged?.Invoke();
        }
    }

}
