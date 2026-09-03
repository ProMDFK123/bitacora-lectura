using Bitacora_API.Domain.Entities;
using Bitacora_API.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bitacora_API.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Capa repositorio para la entidad Obra, implementando la interfaz
    /// IObraRepository. Esta clase proporciona los llamados a la base de datos
    /// para las opraciones CRUD relacionadas con la entidad Obra.
    /// </summary>
    public class ObraRepository : IObraRepository
    {
        /* Referencia al contexto de la base de datos que permite la interacción
        con la misma. */
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor del repositorio que recibe una instancia del contexto
        /// de la base de datos mediante inyección de dependencias.
        /// </summary>
        /// <param name="context">Instancia del contexto de la base de datos.</param>
        public ObraRepository(AppDbContext context){ _context = context; }

        /// <summary>
        /// Busca una obra en la base de datos mediante su identificador y el
        /// identificador del usuario que corresponde
        /// </summary>
        /// <param name="id">Código identificador de la obra a buscar en la
        /// base de datos.</param>
        /// <param name="userID">Código identificador del usuario que registró
        /// la obra.</param>
        /// <returns>La obra si se encontró, null en caso contrario.</returns>
        public async Task<Obra?> GetByIdAsync(Guid id, Guid userID)
        {
            return await _context.Obras.FirstOrDefaultAsync(o => o.Id == id &&
                o.UsuarioId == userID);
        }

        /// <summary>
        /// Obtiene el listado completo de obras registradas por un determinado
        /// usuario en la base de datos.
        /// </summary>
        /// <param name="userID">Código identificador del usuario que registró
        /// las obras.</param>
        /// <returns>La lista de obras si se encontraron, null en caso contrario.</returns>
        public async Task<IEnumerable<Obra>> GetAllAsync(Guid userID)
        {
            return await _context.Obras.AsNoTracking().Where(o => o.UsuarioId == userID)
                .ToListAsync();
        }

        /// <summary>
        /// Agrega una nueva obra a la base de datos.
        /// </summary>
        /// <param name="obra">Obra a añadir.</param>
        /// <returns>La obra agregada a la base de datos.</returns>
        public async Task AddAsync(Obra obra)
        {
            await _context.Obras.AddAsync(obra);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza la información de una obra ya existente en la base de 
        /// datos.
        /// </summary>
        /// <param name="obra">La obra a modificar.</param>
        /// <returns>La información actualizada de la obra dentro de la base de
        /// datos.</returns>
        public async Task UpdateAsync(Obra obra)
        {
            _context.Obras.Update(obra);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina una obra de la base de datos.
        /// </summary>
        /// <param name="obra">Obra a eliminar.</param>
        /// <returns>La base de datos actualizada con la obra completamente
        /// eliminada.</returns>
        public async Task DeleteAsync(Obra obra)
        {   
            _context.Obras.Remove(obra);
            await _context.SaveChangesAsync();
        }
    }
}