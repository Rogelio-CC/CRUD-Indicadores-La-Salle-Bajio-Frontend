namespace PruebaAutenticador2.Shared.DTOS.ListaCombos
{
    // DTO para opciones de combo de períodos escolares.
    public class PeriodoEscolarComboDTO
    {
        // Identificador del período escolar.
        public Guid Id { get; set; }

        // Nombre del período escolar.
        public string Nombre { get; set; } = string.Empty;
    }
}
