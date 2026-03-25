using Blazorise;

namespace PruebaAutenticador2.Classes
{
    // Representa el archivo de políticas de una facultad, que se utiliza para manejar ese archivo en la aplicación.
    public class ArchivoPoliticasTemporal
    {
        // Identificador único del archivo de políticas temporal.
        public Guid? Id { get; set; }

        // Nombre del archivo de políticas temporal
        public string NombreArchivo { get; set; } = "";

        // Tipo o extensión del archivo de políticas temporal.
        public string? Tipo { get; set; }

        // Indica si es un nuevo archivo de políticas subido o no.
        public bool EsNuevoArchivo { get; set; }

        // Indica si el archivo de políticas esta marcado para eliminarse
        // posteriormente de forma permanente cuando se crea la facultad.
        public bool MarcarEvidenciaParaEliminar { get; set; }

        // Atributo usado para pasar el archivo de políticas temporal a uno permanente cuando se crea la facultad.
        // El tipo IFileEntry es exclusivamente de la librería Blazorise.
        public IFileEntry? file { get; set; }
    }
}
