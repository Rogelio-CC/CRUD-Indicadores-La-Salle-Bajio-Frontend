
public class Evidence
{
    // Atributos de la clase Evidencia
    public Guid Id { get; set; }
    public string NombreArchivo { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public byte[] Contenido { get; set; } = Array.Empty<byte>();
    public Guid IndicadorId { get; set; }
    public string Indicador { get; set; } = null!;
}


