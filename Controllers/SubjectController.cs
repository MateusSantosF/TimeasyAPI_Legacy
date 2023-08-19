

using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeasyAPI.src.DTOs.Subject.Requests;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class SubjectController : MainController
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService) { 
            _subjectService = subjectService;   
        }


        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok(await _subjectService.CreateAsync(request));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> UpdateSubjectAsync([FromBody] UpdateSubjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }
            await _subjectService.UpdateAsync(request);
            return Ok();
        }


        /// <summary>
        /// Retorna todas as disciplinas paginadas
        /// </summary>
        /// <param name="page">Indice da página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <returns>teste</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPaged(int page = 1, int pageSize = 10)
        {
            return Ok(await _subjectService.GetAllAsync(page, pageSize));
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> RemoveByIdAsync(Guid id)
        {
            await _subjectService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
