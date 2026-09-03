using Bitacora_API.DTOs.Obra;

namespace Bitacora_API.Application.Interfaces
{
    public interface IObraService
    {
        Task<ObraResponseDTO?> GetById(Guid id, Guid userID);
        Task<IEnumerable<ObraResponseDTO>> GetAll(Guid userID);
        Task<ObraResponseDTO> Create(ObraDTO dto, Guid userID);
        Task<bool> Update(Guid id, ObraDTO dto, Guid userID);
        Task<bool> Delete(Guid id, Guid userID);
    }
}