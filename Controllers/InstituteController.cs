using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeasyAPI.src.DTOs.Institute.Request;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class InstituteController : MainController
    {
        private readonly IInstituteServices _instituteServices;
        private readonly IIntervalServices _intervalServices;

        /// <summary>
        ///  Construtor do controller
        /// </summary>
        public InstituteController(IInstituteServices instituteServices, IIntervalServices intervalServices)
        {
            _instituteServices = instituteServices;
            _intervalServices = intervalServices;
        }

        /// <summary>
        /// Atualiza a instituição de ensino
        /// </summary>
        /// <param name="request">Propriedades da instituição a ser atualizada</param>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInstituteRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }
            await _instituteServices.UpdateAsync(request);
            return NoContent();
        }

        /// <summary>
        /// Retorna a instituição de ensino com base no Id
        /// </summary>
        /// <param name="instituteId">Id da instituição de ensino a ser buscada</param>
        [HttpGet]
        public async Task<IActionResult> FindById(string instituteId)
        {
            return Ok(await _instituteServices.GetById(instituteId));
        }

        /// <summary>
        /// Adiciona novos intervalos na instituição de ensino
        /// </summary>
        /// <param name="request">Propriedades da instituição a ser atualizada</param>
        [HttpPatch("intervals")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> AddIntervals([FromBody] AddIntervalsRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            await _intervalServices.AddIntervalsAsync(request);
            return NoContent();
        }

        /// <summary>
        ///  Deleta o intervalo informado da instituição de ensino
        /// </summary>
        /// <param name="intervalId">Id do intervalo</param>
        [HttpDelete("intervals")]
        public async Task<IActionResult> RemoveInterval(string intervalId)
        {
            await _intervalServices.DeleteAsync(intervalId);
            return NoContent();
        }

    }
}
