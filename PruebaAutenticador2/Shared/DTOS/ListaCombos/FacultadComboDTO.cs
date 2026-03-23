namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de facultades.
    public class FacultadComboDTO
    {
        // Identificador de la facultad.
        public Guid Id { get; set; }

        // Nombre de la facultad.
        public string Nombre { get; set; } = string.Empty;
    }
}
