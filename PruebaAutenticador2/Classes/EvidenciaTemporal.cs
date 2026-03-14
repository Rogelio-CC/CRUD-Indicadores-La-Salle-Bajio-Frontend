using Blazorise;

namespace PruebaAutenticador2.Classes
{
    // Atributos de la clase que representa una evidencia temporal, que se utiliza para manejar archivos de evidencia en la aplicación.
    public class EvidenciaTemporal
    {
        public Guid? Id { get; set; }
        public string NombreArchivo { get; set; } = "";
        public string? Tipo { get; set; }
        public bool EsNuevaEvidencia { get; set; }
        public bool MarcarEvidenciaParaEliminar { get; set; }

        public IFileEntry? file { get; set; }
    }
}
