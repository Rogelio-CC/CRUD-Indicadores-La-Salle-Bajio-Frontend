namespace PruebaAutenticador2.Classes
{
    // Representa un grupo de indicadores utilizado para su organización.
    public class GroupOfIndicators
    {
        // Identificador único del grupo de indicadores.
        public Guid Id { get; set; }

        // Número del grupo de indicadores (no es lo mismo que el su Id; sirve para ser otro identificador pero más entendible que un Id).
        public int NumeroGrupo { get; set; }

        // Descripción del grupo de indicadores.
        public string DescripcionGrupo { get; set; } = null!;
    }
}
