namespace PruebaAutenticador2.Shared.DTOS.Evidencia
{
    // DTO para listar evidencias, contiene solo los campos necesarios para mostrar en una lista
    public class EvidenciaListDto
    {
        // Obtiene o establece el identificador único de la evidencia.
        public Guid Id { get; set; }

        // Obtiene o establece el nombre del archivo.
        public string NombreArchivo { get; set; } = null!;

        // Obtiene o establece el tipo de la evidencia.
        public string Tipo { get; set; } = null!;
    }

}
