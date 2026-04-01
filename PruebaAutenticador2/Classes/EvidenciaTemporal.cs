namespace PruebaAutenticador2.Classes
{
    // Representa una evidencia temporal, que se utiliza para manejar archivos de evidencia en la aplicación.
    public class EvidenciaTemporal
    {
        // Identificador único de la evidencia temporal.
        public Guid? Id { get; set; }

        // Nombre de la evidencia temporal
        public string NombreArchivo { get; set; } = "";

        // Tipo o extensión de la evidencia temporal.
        public string? Tipo { get; set; }

        // Indica si es una nueva evidencia subida o no.
        public bool EsNuevaEvidencia { get; set; }

        // Indica si la evidencia esta marcada para eliminarse
        // posteriormente de forma permanente cuando se crea un indicador.
        public bool MarcarEvidenciaParaEliminar { get; set; }

        // Atributo usado para pasar el archivo temporal a uno permanente cuando se crea el indicador.
        public byte[] Contenido { get; set; } = Array.Empty<byte>();
    }
}
