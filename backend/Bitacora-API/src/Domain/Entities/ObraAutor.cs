namespace Bitacora_API.Domain.Entities
{
    public class ObraAutor
    {
        // Claves foraneas
        public Guid ObraId { get; set; } // Clave foránea que referencia a la 
                                        // obra.
        public Guid AutorId { get; set; } // Clave foránea que referencia al 
                                        // autor.
        
        // Elementos foraneos de la obra y el autor.
        public Obra Obra { get; set; } = null!;
        public Autor Autor { get; set; } = null!;
    }
}