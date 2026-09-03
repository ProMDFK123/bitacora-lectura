using Bitacora_API.Domain.Entities;

namespace Bitacora_API.Application.Interfaces
{
    public interface IObraRepository
    {
        Task<Obra?> GetByIdAsync(Guid id, Guid userID);
        Task<IEnumerable<Obra>> GetAllAsync(Guid userID);
        Task AddAsync(Obra obra);
        Task UpdateAsync(Obra obra);
        Task DeleteAsync(Obra obra);
    }
}