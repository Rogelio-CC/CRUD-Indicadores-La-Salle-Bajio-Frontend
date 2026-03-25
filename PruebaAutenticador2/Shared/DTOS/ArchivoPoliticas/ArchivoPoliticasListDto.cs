namespace PruebaAutenticador2.Shared.DTOS.ArchivoPoliticas
{
    // DTO para mostrar el archivo de políticas en forma de lista, contiene solo los campos necesarios para mostrar.
    public class ArchivoPoliticasListDto
    {
        // Obtiene o establece el identificador único del archivo de políticas.
        public Guid Id { get; set; }

        // Obtiene o establece el nombre del archivo de políticas.
        public string NombreArchivo { get; set; } = null!;

        // Obtiene o establece el tipo del archivo de políticas.
        public string Tipo { get; set; } = null!;
    }
}
