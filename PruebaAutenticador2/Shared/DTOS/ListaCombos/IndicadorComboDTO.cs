namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de indicadores.
    public class IndicadorComboDTO
    {
        // Identificador del indicador.
        public Guid Id { get; set; }

        // Nombre del indicador.
        public string Nombre { get; set; } = string.Empty;
    }
}
