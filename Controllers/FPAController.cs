
using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.DTOs.FPA.requests;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[Controller]")]
    public class FPAController : MainController
    {

        private IFPAServices _fpaServices;

        public FPAController(IFPAServices fpaServices)
        {
            _fpaServices = fpaServices;        
        }

        [HttpPost]
        public async Task<IActionResult> createFPA([FromBody] FillFPARequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }
            await _fpaServices.FillAsync(request);
            return NoContent();
        }
    }
}
