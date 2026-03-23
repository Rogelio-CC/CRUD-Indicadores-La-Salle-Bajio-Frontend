namespace PruebaAutenticador2.Classes
{
    // Representa una evidencia asociada a un indicador.
    public class Evidence
    {
        // Identificador único de la evidencia.
        public Guid Id { get; set; }

        // Nombre del archivo de la evidencia.
        public string NombreArchivo { get; set; } = null!;

        // Tipo o extensión del archivo.
        public string Tipo { get; set; } = null!;

        // Contenido binario del archivo.
        public byte[] Contenido { get; set; } = Array.Empty<byte>();

        // Identificador del indicador al que pertenece la evidencia.
        public Guid IndicadorId { get; set; }

        // Nombre del inidicador.
        public string Indicador { get; set; } = null!;
    }
}



