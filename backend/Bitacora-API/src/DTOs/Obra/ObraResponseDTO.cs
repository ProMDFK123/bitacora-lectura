namespace Bitacora_API.DTOs.Obra
{
    public class ObraResponseDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string TipoObra { get; set; } = null!;
        public DateTime? Publicacion { get; set; }
        public Guid? SagaId { get; set; }
    }
}