namespace Bitacora_API.Domain.Entities
{
    public class Obra
    {
        // Propiedades de la obra.
        public Guid Id { get; set; }
        
        public Guid UsuarioId { get; set; } // Clave foránea que referencia al
                                            // usuario que creó la obra.

        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string TipoObra { get; set; } = null!;
        public DateTime? Publicacion { get; set; }

        public Guid? SagaId { get; set; } // Clave foránea que referencia a la 
                                        // saga a la que pertenece la obra (si 
                                        // aplica).

        // Elementos foraneos de la obra.
        public Usuario Usuario { get; set; } = null!;
        public Saga? Saga { get; set; }

        // Elementos relacionados con la obra.
        public ICollection<Autor> Autores { get; set; } = new List<Autor>();
        public ICollection<Edicion> Ediciones { get; set; } = new List<Edicion>();
        public ICollection<Genero> Generos { get; set; } = new List<Genero>();
    }
}