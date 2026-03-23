namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de directrices.
    public class DirectrizComboDTO
    {
        // Identificador de la directriz.
        public Guid Id { get; set; }

        // Nombre de la directriz.
        public string Nombre { get; set; } = string.Empty;
    }
}
