using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.DTOs.User.Requests;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController: MainController
    {   

        private readonly IUserServices _userService;

        /// <summary>
        ///  Construtor do controller
        /// </summary>
        public UserController(  IUserServices userService)
        {
            _userService = userService;
        }

        /// <summary>
        ///  Realiza a autenticação do usuário
        /// </summary>
        /// <param name="request">Email e senha do usuário</param>
        /// <returns>Usuário com suas informações e Token de acesso</returns>
        [HttpPost("auth")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public async Task<IActionResult> Auth([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            return Ok(await _userService.AuthAsync(request));
        }

        /// <summary>
        /// Cria o usuário root (administrador) da aplicação, assim como, uma instituição de ensino.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Informações do novo usuário e instituição criados</returns>
        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }
    
            return Ok(await _userService.CreateRootUserAsync(request));
        }
    }
}
