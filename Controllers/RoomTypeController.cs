using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]

    public class RoomTypeController : MainController
    {
        private readonly IRoomTypeServices _roomTypeService;

        /// <summary>
        ///  Construtor do controller
        /// </summary>
        public RoomTypeController(IRoomTypeServices roomTypeServices)
        {
            _roomTypeService = roomTypeServices;
        }

        /// <summary>
        /// Cria um novo tipo de sala
        /// </summary>
        /// <param name="request">Informações do novo tipo de sala a ser criado</param>
        /// <returns>Novp Tipo de sala criado com seu Id</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRoomTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok(await _roomTypeService.CreateAsync(request));
        }

        /// <summary>
        /// Retorna todos os tipos de sala de forma paginada
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <returns>Uma lista de tipo de salas de forma paginada</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllPagedAsync(int page = 1, int pageSize = 10)
        {
            return Ok(await _roomTypeService.GetAllAsync(page, pageSize));
        }

        /// <summary>
        /// Atualiza o tipo de sala informado
        /// </summary>
        /// <param name="request">Propriedades a serem atualizadas do tipo da sala</param>
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateRoomTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }
            await _roomTypeService.UpdateAsync(request);
            return NoContent();
        }

        /// <summary>
        /// Deleta o tipo de sala 
        /// </summary>
        /// <param name="id">Id do tipo de sala a ser deletado</param>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            await _roomTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
