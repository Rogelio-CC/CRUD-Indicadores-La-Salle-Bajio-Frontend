namespace PruebaAutenticador2.Shared.DTOS.ArchivoPoliticas
{
    // DTO que representa un archivo de políticas asociado a una facultad.
    public class ArchivoPoliticasDto
    {
        // Identificador único del archivo de las políticas.
        public Guid Id { get; set; }

        // Nombre del archivo de las políticas.
        public string NombreArchivo { get; set; } = null!;

        // Tipo o extensión del archivo de las políticas.
        public string Tipo { get; set; } = null!;

        // Contenido binario del archivo de las políticas.
        public byte[] Contenido { get; set; } = Array.Empty<byte>();

        // Identificador de la facultad al que pertenece el archivo de las políticas.
        public Guid FacultadId { get; set; }

        // Nombre de la facultad.
        public string Facultad { get; set; } = null!;
    }
}
