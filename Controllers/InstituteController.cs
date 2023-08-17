using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.DTOs.Institute.Request;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class InstituteController : ControllerBase
    {
        private readonly IInstituteServices _instituteServices;
        public InstituteController(IInstituteServices instituteServices)
        {
            _instituteServices = instituteServices;
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateInstituteRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }
            await _instituteServices.UpdateAsync(request);
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
