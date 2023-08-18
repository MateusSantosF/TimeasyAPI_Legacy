
using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomTypeController : ControllerBase
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
        public async Task<IActionResult> GetAllPagedAsync(int page = 1, int pageSize = 10)
        {
            return Ok(await _roomTypeService.GetAllAsync(page, pageSize));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            await _roomTypeService.DeleteAsync(id);
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
