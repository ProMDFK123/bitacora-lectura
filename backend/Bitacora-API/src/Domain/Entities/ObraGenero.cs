namespace Bitacora_API.Domain.Entities
{
    public class ObraGenero
    {
        // Claves foraneas
        public Guid ObraId { get; set; } // Clave foránea que referencia a la 
                                        // obra.
        public Guid GeneroId { get; set; } // Clave foránea que referencia al 
                                         // género.
        
        // Elementos foraneos de la obra y el género.
        public Obra Obra { get; set; } = null!;
        public Genero Genero { get; set; } = null!;
    }
}