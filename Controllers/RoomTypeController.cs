
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
        public async Task<IActionResult> CreateAsync(CreateRoomTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new AppException(GetModelErrors());
            }

            return Ok(await _roomTypeService.CreateAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPagedAsync(int page, int pageSize)
        {
            return Ok(await _roomTypeService.GetAllAsync(page, pageSize));
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
