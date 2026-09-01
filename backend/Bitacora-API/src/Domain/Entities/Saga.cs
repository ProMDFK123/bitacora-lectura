namespace Bitacora_API.Domain.Entities
{
    public class Saga
    {
        // Propiedades de la saga.
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; } // Clave foránea que referencia al
                                            // usuario que creó la saga.

        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        // Elementos foraneos de la saga.
        public Usuario Usuario { get; set; } = null!;

        // Obras relacionadas con la saga.
        public ICollection<Obra> Obras { get; set; } = new List<Obra>();
    }
}