namespace Bitacora_API.Domain.Entities
{
    public class EntradaBitacora
    {
        // Propiedades de la entrada de bitácora.
        public Guid Id { get; set; }

        public Guid SesionLecturaId { get; set; } // Clave foránea que referencia 
                                                // a la sesión de lectura a la 
                                                // que pertenece la entrada.
        public Guid LecturaId { get; set; } // Clave foránea que referencia a la
                                            // lectura a la que pertenece la 
                                            // entrada.

        public DateTime Fecha { get; set; }

        public string Titulo { get; set; } = null!;
        public string Contenido { get; set; } = null!;
        public bool Spoilers { get; set; }

        // Elementos foraneos de la entrada de bitácora.
        public SesionLectura SesionLectura { get; set; } = null!;
        public Lectura Lectura { get; set; } = null!;
    }
}