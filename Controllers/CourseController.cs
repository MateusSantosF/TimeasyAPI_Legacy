using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.DTOs.Course.Requests;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers    
{
    [Route("api/[controller]")]
    public class CourseController : MainController
    {

        private readonly ICourseServices _courseService;
        private readonly ITokenService _tokenService;
        public CourseController(ICourseServices courseServices, ITokenService tokenService)
        {
            _courseService = courseServices;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok(await _courseService.CreateAsync(request, _tokenService.GetInstituteIdByCurrentUser(User)));
        }
    }
}
