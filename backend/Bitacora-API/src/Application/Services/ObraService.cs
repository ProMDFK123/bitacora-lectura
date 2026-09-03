using Bitacora_API.DTOs.Obra;
using Bitacora_API.Application.Interfaces;
using Bitacora_API.Domain.Entities;

namespace Bitacora_API.Application.Services
{
    /// <summary>
    /// Capa de servicios para la entidad Obra, implementando la interfaz
    /// IObraService. Esta clase proporciona la lógica de negocio y las operaciones
    /// relacionados con la entidad Obra, interactuando con su correspondiente
    /// repositorio para realizar las operaciones CRUD y los llamados a la base
    /// de datos.
    /// </summary>
    public class ObraService : IObraService
    {
        // Instancia del repositorio de la entidad Obra.
        private readonly IObraRepository _repository;

        /// <summary>
        /// Constructor del servicio que recibe una instancia del repositorio
        /// de la entidad Obra.
        /// </summary>
        /// <param name="repository">Instancia del repositorio de la entidad
        /// Obra.</param>
        public ObraService(IObraRepository repository){ _repository = repository; }

        /// <summary>
        /// Método para obtener una obra dado su identificador y el del usuario
        /// que registro la obra.
        /// </summary>
        /// <param name="id">Código identificador de la obra a buscar.</param>
        /// <param name="userID">Código identificador del usuario que registró
        /// la obra.</param>
        /// <returns>La obra si se encontró, null en caso contrario.</returns>
        public async Task<ObraResponseDTO?> GetById(Guid id, Guid userID)
        {
            var obra = await _repository.GetByIdAsync(id, userID);

            if (obra is null) return null;

            return MapDTO(obra);
        }

        /// <summary>
        /// Método para obtener el listado de todas las obras registradas por
        /// un determinado usuario. El usuario se determina según su identificador.
        /// </summary>
        /// <param name="userID">Código identificador del usuario que registró
        /// las obras.</param>
        /// <returns>El listado de las obras registradas por el usuario, null
        /// en caso contrario.</returns>
        public async Task<IEnumerable<ObraResponseDTO>> GetAll(Guid userID)
        {
            var obras = await _repository.GetAllAsync(userID);

            return obras.Select(MapDTO);
        }

        /// <summary>
        /// Método para crear y registrar una nueva obra en el sistema.
        /// </summary>
        /// <param name="dto">DTO que contiene la información relevante para la
        /// creación de una obra.</param>
        /// <param name="userID">Código identificador del usuario que está por
        /// registrar la obra.</param>
        /// <returns>La obra creada mapeada a DTO.</returns>
        public async Task<ObraResponseDTO> Create(ObraDTO dto, Guid userID)
        {
            var obra = new Obra { Id = Guid.NewGuid(), UsuarioId = userID,
                Titulo = dto.Titulo, Descripcion = dto.Descripcion,
                TipoObra = dto.TipoObra, Publicacion = dto.Publicacion,
                SagaId = dto.SagaId };

            await _repository.AddAsync(obra);

            return MapDTO(obra);
        }

        /// <summary>
        /// Método que permite actualizar/modificar los datos de una obra ya
        /// existente y creada por el mismo usuario que intenta editarla.
        /// </summary>
        /// <param name="id">Código identificador de la obra a editar.</param>
        /// <param name="dto">DTO con la nueva información que contendrá la 
        /// obra.</param>
        /// <param name="userID">Código identificador del usuario que registró
        /// la obra (y por lo tanto, quien va a modificar la información de la
        /// obra.</param>
        /// <returns>'true' en caso de una actualización exitosa de los datos,
        /// 'false' en caso contrario.</returns>
        public async Task<bool> Update(Guid id, ObraDTO dto, Guid userID)
        {
            var obra = await _repository.GetByIdAsync(id, userID);

            if (obra is null) return false;

            obra.Descripcion = dto.Descripcion;
            obra.Publicacion = dto.Publicacion;
            obra.TipoObra = dto.TipoObra;
            obra.Titulo = dto.Titulo;
            obra.SagaId = dto.SagaId;

            await _repository.UpdateAsync(obra);

            return true;
        }

        /// <summary>
        /// Método que permite la eliminación de una obra de la biblioteca
        /// personal de un determinado usuario y de la base de datos.
        /// </summary>
        /// <param name="id">Código identificador de la obra a eliminar.</param>
        /// <param name="userID">Código identificador del usuario al que pertenece
        /// la obra (dentro de la base de datos).</param>
        /// <returns>'true' si la obra se eliminó correctamente, 'false' en caso
        /// contrario.</returns>
        public async Task<bool> Delete(Guid id, Guid userID)
        {
            var obra = await _repository.GetByIdAsync(id, userID);

            if (obra is null) return false;

            await _repository.DeleteAsync(obra);

            return true;
        }

        /// <summary>
        /// Método privado y auxiliar que convierte (mapea) una entidad Obra en
        /// un DTO de respuesta.
        /// </summary>
        /// <param name="obra">Instancia de obra que se convertirá en un DTO de
        /// respuesta.</param>
        /// <returns>DTO con la información más relevante y el código identificador
        /// de la obra.</returns>
        private static ObraResponseDTO MapDTO(Obra obra)
        {
            return new ObraResponseDTO { Id = obra.Id, Descripcion = obra.Descripcion,
                TipoObra = obra.TipoObra, Publicacion = obra.Publicacion,
                Titulo = obra.Titulo, SagaId = obra.SagaId };
        }
    }
}