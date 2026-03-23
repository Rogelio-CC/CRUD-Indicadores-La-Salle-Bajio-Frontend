namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de estrategias.
    public class EstrategiaComboDTO
    {
        // Identificador de la estrategia.
        public Guid Id { get; set; }

        // Nombre de la estrategia.
        public string Nombre { get; set; } = string.Empty;
    }
}
