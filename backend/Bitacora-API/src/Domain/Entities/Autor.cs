namespace Bitacora_API.Domain.Entities
{
    public class Autor
    {
        // Propiedades del autor.
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; } // Clave foránea que referencia al
                                            // usuario que creó el autor.

        public string Nombre { get; set; } = null!;
        public string? Biografia { get; set; }

        // Elementos foraneos del autor.
        public Usuario Usuario { get; set; } = null!;

        // Elementos relacionados con el autor.
        public ICollection<Obra> Obras { get; set; } = new List<Obra>();
    }
}