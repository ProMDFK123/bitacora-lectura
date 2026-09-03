namespace Bitacora_API.DTOs.Obra
{
    public class ObraDTO
    {
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string TipoObra { get; set; } = null!;
        public DateTime? Publicacion { get; set; }
        public Guid? SagaId { get; set; }
    }
}