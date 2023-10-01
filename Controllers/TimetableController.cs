
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

        [HttpGet("rooms")]
        public async Task<IActionResult> GetTimetableRooms(Guid timetableId)
        {
            return Ok(await _timetableServices.GetTimetableRooms(timetableId));
        }

        [HttpGet("subjects")]
        public async Task<IActionResult> GetTimetableSubjects(Guid timetableId)
        {
            return Ok(await _timetableServices.GetTimetableSubjects(timetableId));
        }


        [HttpGet("courses")]
        public async Task<IActionResult> GetTimetableCourses(Guid timetableId)
        {
            return Ok(await _timetableServices.GetTimetableCourses(timetableId));
        }

        [HttpGet("courses-subjects")]
        public async Task<IActionResult> GetTimetableCoursesWithSubjects(Guid timetableId)
        {
            return Ok(await _timetableServices.GetTimetableCoursesWithSubjects(timetableId));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPagedAsync(int page = 1, int pageSize = 10)
        {
            return Ok(await _timetableServices.GetAllAsync(page, pageSize));
        }

        /// <summary>
        /// Deleta uma disciplina associada a um curso 
        /// </summary>
        /// <param name="timetableId"></param>
        /// <param name="subjectId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>

        [HttpDelete("subject")]
        public async Task<IActionResult> RemoveSubjectFromTimetable(Guid timetableId, Guid subjectId, Guid courseId)
        {

            await _timetableServices.RemoveSubjectFromTimetable(timetableId, subjectId, courseId);
           return NoContent();
        }


        [HttpDelete("course")]
        public async Task<IActionResult> RemoveCoursetFromTimetable(Guid timetableId, Guid courseId)
        {
            await _timetableServices.RemoveCourseFromTimetable(timetableId, courseId);
            return NoContent();
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
