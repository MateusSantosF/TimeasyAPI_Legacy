

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

        /// <summary>
        ///  Construtor do controller
        /// </summary>
        public SubjectController(ISubjectService subjectService) { 
            _subjectService = subjectService;   
        }

        /// <summary>
        /// Cria uma nova disciplina
        /// </summary>
        /// <param name="request">Informações da nova disciplina</param>
        /// <returns>Retorna a nova disciplina com seu Id.</returns>
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
        ///  Atualiza a disciplina informada
        /// </summary>
        /// <param name="request">Informações da disciplina a serem atualizadas</param>
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
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <returns>teste</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPaged(int page = 1, int pageSize = 10)
        {
            return Ok(await _subjectService.GetAllAsync(page, pageSize));
        }

        /// <summary>
        /// Deleta uma disciplina com base no Id
        /// </summary>
        /// <param name="id">Id da disciplina</param>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> RemoveByIdAsync(Guid id)
        {
            await _subjectService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
