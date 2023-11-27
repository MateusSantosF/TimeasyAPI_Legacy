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

        /// <summary>
        ///  Construtor da controller
        /// </summary>
        public CourseController(ICourseServices courseServices, ITokenService tokenService)
        {
            _courseService = courseServices;
            _tokenService = tokenService;
        }

        /// <summary>
        ///  Retorna todos os cursos de forma paginada
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <param name="name">Nome do curso</param>

        /// <returns>Uma lista de cursos de forma paginada</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPagedAsync(int page = 1, int pageSize = 10, string? name = null)
        {
            return Ok(await _courseService.GetAllAsync(page, pageSize, name));
        }

        /// <summary>
        /// Cria um novo curso no sistema
        /// </summary>
        /// <param name="request">Informações do novo Curso a ser criado</param>
        /// <returns>Curso Criado com seu Id</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok(await _courseService.CreateAsync(request, _tokenService.GetInstituteIdByCurrentUser(User)));
        }

        /// <summary>
        /// Atualiza um Curso. Removendo todas suas disciplinas e adicionando novamente com base nas disciplinas informadas
        /// </summary>
        /// <param name="request">Informações do curso a serem alteradas</param>
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }
            await _courseService.UpdateAsync(request);
            return NoContent();
        }

        /// <summary>
        /// Deleta um curso do sistema
        /// </summary>
        /// <param name="id">Id do curso a ser deletado</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _courseService.RemoveByIdAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Remove uma disciplina associada a um curso
        /// </summary>
        /// <param name="courseId">Id do curso</param>
        /// <param name="subjectId">Id da disciplina</param>
        /// <returns></returns>
        [HttpDelete("subject")]
        [ProducesResponseType((int)StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCourseSubjectAsync([FromBody] DeleteCourseSubjectsRequest request)
        {
            await _courseService.RemoveCourseSubjectByIdAsync(request);
            return NoContent();
        }
    }
}
