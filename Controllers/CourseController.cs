using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.DTOs.Course.Requests;

namespace TimeasyAPI.Controllers    
{
    [Route("api/[controller]")]
    public class CourseController : MainController
    {


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok();
        }
    }
}
