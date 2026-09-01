namespace Bitacora_API.Domain.Entities
{
    public class Usuario
    {
        // Propiedades del usuario.
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        // Elementos creados por el usuario.
        public ICollection<Obra> Obras { get; set; } = new List<Obra>();
        public ICollection<Autor> Autores { get; set; } = new List<Autor>();
        public ICollection<Saga> Sagas { get; set; } = new List<Saga>();
        public ICollection<Edicion> Ediciones { get; set; } = new List<Edicion>();
        public ICollection<Biblioteca> Bibliotecas { get; set; } = new List<Biblioteca>();
        public ICollection<Lectura> Lecturas { get; set; } = new List<Lectura>();
    }
}