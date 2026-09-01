namespace Bitacora_API.Domain.Entities
{
    public class Biblioteca
    {
        // Claves foráneas que referencian a la edición y al usuario que posee 
        // la obra en su biblioteca.
        public Guid EdicionId { get; set; }
        public Guid UsuarioId { get; set; }

        // Propiedades de la biblioteca.
        public DateTime FechaAgregado { get; set; }

        // Elementos foraneos de la biblioteca.
        public Edicion Edicion { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
    }
}