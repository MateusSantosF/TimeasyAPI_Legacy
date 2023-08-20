
using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.DTOs.Timetable.Requests;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class TimetableController : MainController
    {

        private readonly ITimetableServices _timetableServices;
        private readonly ITokenService _tokenService;

        public TimetableController(ITimetableServices timetableServices, ITokenService tokenService)
        {
            _timetableServices = timetableServices;
            _tokenService = tokenService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPagedAsync(int page = 1, int pageSize = 10)
        {
            return Ok(await _timetableServices.GetAllAsync(page, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]CreateTimetableRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok(await _timetableServices.CreateAsync(request, _tokenService.GetInstituteIdByCurrentUser(User)));
        }
    }
}
