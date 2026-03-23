namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de grupos de indicadores.
    public class GrupoIndicadoresComboDTO
    {
        // Identificador del grupo de indicadores.
        public Guid Id { get; set; }

        // Nombre del grupo de indicadores.
        public string Nombre { get; set; } = string.Empty;
    }
}
