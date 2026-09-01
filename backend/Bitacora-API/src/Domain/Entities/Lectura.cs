using Bitacora_API.Domain.Enum;

namespace Bitacora_API.Domain.Entities
{
    public class Lectura
    {
        // Propiedades de la lectura.
        public Guid Id { get; set; }
        public Guid EdicionId { get; set; } // Clave foránea que referencia a 
                                            // la edición que se está leyendo.
        public Guid UsuarioId { get; set; } // Clave foránea que referencia al 
                                            // usuario que está leyendo la obra.

        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public EstadoLectura Estado { get; set; }
        public int NumeroRelecturas { get; set; }

        // Elementos foraneos de la lectura.
        public Edicion Edicion { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;

        // Elementos relacionados con la lectura.
        public ICollection<SesionLectura> Sesiones { get; set; } = new List<SesionLectura>();
        public ICollection<EntradaBitacora> Entradas { get; set; } = new List<EntradaBitacora>();
        public Valoracion? Valoracion { get; set; }
    }
}