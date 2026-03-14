namespace PruebaAutenticador2.Shared.DTOS.Evidencia
{
    // DTO para listar evidencias, contiene solo los campos necesarios para mostrar en una lista
    public class EvidenciaListDto
    {
        public Guid Id { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public string Tipo { get; set; } = null!;
    }

}
