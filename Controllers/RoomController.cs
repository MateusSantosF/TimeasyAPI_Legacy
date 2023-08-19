using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : MainController
    {

        private readonly IRoomServices _roomServices;

        /// <summary>
        ///  Construtor do controller
        /// </summary>
        public RoomController(IRoomServices roomServices)
        {
            _roomServices = roomServices;
        }

        /// <summary>
        /// Cria uma nova sala
        /// </summary>
        /// <param name="request">Informações da sala a ser criada</param>
        /// <returns>Nova sala criada com seu Id</returns>
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok(await _roomServices.CreateAsync(request));
        }

        /// <summary>
        /// Realiza a atualização da sala
        /// </summary>
        /// <param name="request">Informações da sala a ser atualizada</param>
        [HttpPatch]
        public async Task<IActionResult> UpdateRoomAsync([FromBody] UpdateRoomRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }
            await _roomServices.UpdateAsync(request);
            return Ok();
        }

        /// <summary>
        /// Retorna todas as salas de forma paginada
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <returns>Uma lista de salas de forma paginada</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPaged(int page = 1, int pageSize = 10)
        {
            return Ok(await _roomServices.GetAllAsync(page, pageSize));
        }

        /// <summary>
        ///  Deleta a sala com base no Id informado
        /// </summary>
        /// <param name="id">Id da sala</param>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> RemoveByIdAsync(Guid id)
        {
            await _roomServices.RemoveByIdAsync(id);
            return NoContent();
        }

    }
}
