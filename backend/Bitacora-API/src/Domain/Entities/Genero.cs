namespace Bitacora_API.Domain.Entities
{
    public class Genero
    {
        // Propiedades del género.
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;

        // Obras relacionadas con el género.
        public ICollection<Obra> Obras { get; set; } = new List<Obra>();
    }
}