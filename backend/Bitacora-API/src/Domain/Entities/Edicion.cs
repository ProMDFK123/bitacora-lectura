using Bitacora_API.Domain.Enum;

namespace Bitacora_API.Domain.Entities
{
    public class Edicion
    {
        // Propiedades de la edición.
        public Guid Id { get; set; }
        public Guid ObraId { get; set; } // Clave foránea que referencia a la 
                                        // obra a la que pertenece la edición.
        public Guid UsuarioId { get; set; } // Clave foránea que referencia al
                                            // usuario que creó la edición.

        public string Editorial { get; set; } = null!;
        public int? Anio { get; set; }
        public int? Paginas { get; set; }
        public int? duracionMinutos { get; set; }
        public string? PortadaURL { get; set; }
        public string? Isbn { get; set; }
    

        // Elementos foraneos de la edición.
        public Obra Obra { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;

        public Formato Formato { get; set; }

        // Elementos relacionados con la edición.
        public ICollection<Lectura> Lecturas { get; set; } = new List<Lectura>();
        public ICollection<Biblioteca> Bibliotecas { get; set; } = new List<Biblioteca>();
    }
}