using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.DTOs.Teacher.Requests;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : MainController
    {

        private readonly ITeacherServices _teacherServices;
        private readonly ITokenService _tokenService;

        public TeacherController(ITeacherServices teacherServices, ITokenService tokenService)
        {
            _teacherServices = teacherServices;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Retorna todos os professores de forma paginada.
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Número de items por página</param>
        [HttpGet]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int page = 1, int pageSize = 10)
        {
            return Ok(await _teacherServices.GetAllAsync(page, pageSize));
        }

        /// <summary>
        /// Cria um novo professor no sistema
        /// </summary>
        /// <param name="request">Informações do professor</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTeacherRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            var userInstituteId = _tokenService.GetInstituteIdByCurrentUser(User);

            return Ok(await _teacherServices.CreateAsync(request, userInstituteId));
        }

        /// <summary>
        /// Atualiza o professor com base nas informações informadas
        /// </summary>
        /// <param name="request">Informações a serem atualizadas</param>
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateTeacherRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            await _teacherServices.UpdateAsync(request);
            return NoContent();
        }
    

        /// <summary>
        ///  Deleta um professor com base em seu Id
        /// </summary>
        /// <param name="id">Id do professor</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _teacherServices.RemoveByIdAsync(id);
            return NoContent();
        }
    }
}
