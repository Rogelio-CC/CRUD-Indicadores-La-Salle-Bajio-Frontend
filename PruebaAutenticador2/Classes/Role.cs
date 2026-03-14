
namespace PruebaAutenticador2.Classes
{
    // Atributos de la clase Rol
    public class Role
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Permisos { get; set; } = string.Empty;
    }
}
