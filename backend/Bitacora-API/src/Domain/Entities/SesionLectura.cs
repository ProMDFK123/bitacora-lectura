namespace Bitacora_API.Domain.Entities
{
    public class SesionLectura
    {
        // Propiedades de la sesión de lectura.
        public Guid Id { get; set; }
        public Guid LecturaId { get; set; } // Clave foránea que referencia a 
                                            // la lectura a la que pertenece 
                                            // la sesión.
        public DateTime Fecha { get; set; }
        public decimal Progreso { get; set; } // Porcentaje de progreso de la 
                                            // lectura en la sesión (0 a 100).
        public int? Minutos { get; set; } // Duración de la sesión en minutos 
                                        // (opcional).

        // Elementos foraneos de la sesión de lectura.
        public Lectura Lectura { get; set; } = null!;

        // Elementos relacionados con la sesión de lectura.
        public ICollection<EntradaBitacora> Entradas { get; set; } = new List<EntradaBitacora>();
    }
}