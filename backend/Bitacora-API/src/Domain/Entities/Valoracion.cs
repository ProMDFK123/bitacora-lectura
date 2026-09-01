namespace Bitacora_API.Domain.Entities
{
    public class Valoracion
    {
        // Propiedades de la valoración.
        public Guid Id { get; set; }
        public Guid LecturaId { get; set; } // Clave foránea que referencia a la 
                                            // lectura a la que pertenece la 
                                            // valoración.

        public int Puntuacion { get; set; } // Puntuación de la obra (1 a 5).
        public string? Resena { get; set; } // Comentario opcional sobre la 
                                            // obra.

        public DateTime Fecha { get; set; } // Fecha en la que se realizó la 
                                            // valoración.

        // Elementos foraneos de la valoración.
        public Lectura Lectura { get; set; } = null!;
    }
}