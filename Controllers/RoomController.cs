using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {

        private readonly IRoomServices _roomServices;

        public RoomController(IRoomServices roomServices)
        {
            _roomServices = roomServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok(await _roomServices.CreateAsync(request));
        }

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

        [HttpGet]
        public async Task<IActionResult> GetAllPaged(int page = 1, int pageSize = 10)
        {
            return Ok(await _roomServices.GetAllAsync(page, pageSize));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveByIdAsync(string id)
        {
            await _roomServices.RemoveByIdAsync(id);
            return NoContent();
        }

        private string GetModelErrors()
        {
            var validationErrors = ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)
                                            .ToList();

            return string.Join(" ", validationErrors);
        }
    }
}
