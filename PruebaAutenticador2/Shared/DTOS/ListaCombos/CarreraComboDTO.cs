namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de carreras.
    public class CarreraComboDTO
    {
        // Identificador de la carrera.
        public Guid Id { get; set; }

        // Nombre de la carrera.
        public string Nombre { get; set; } = string.Empty;
    }
}
