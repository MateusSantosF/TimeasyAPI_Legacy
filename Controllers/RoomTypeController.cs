
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]

    public class RoomTypeController : MainController
    {
        private readonly IRoomTypeServices _roomTypeService;

        public RoomTypeController(IRoomTypeServices roomTypeServices)
        {
            _roomTypeService = roomTypeServices;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRoomTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new AppException(GetModelErrors());
            }

            return Ok(await _roomTypeService.CreateAsync(request));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllPagedAsync(int page = 1, int pageSize = 10)
        {
            return Ok(await _roomTypeService.GetAllAsync(page, pageSize));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateRoomTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new AppException(GetModelErrors());
            }
            await _roomTypeService.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            await _roomTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
