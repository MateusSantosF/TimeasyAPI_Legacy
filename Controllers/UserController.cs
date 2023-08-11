using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.Models.Core;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("[Controller]/api")]
    public class UserController: ControllerBase
    {   
        private readonly ILogger<UserController> _logger;
        private readonly ITokenService _tokenService;

        public UserController(ILogger<UserController> logger, ITokenService tokenService) {
            _logger = logger;
            _tokenService = tokenService;
        }


        [HttpGet("auth")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Auth()
        {
            var user = new User() { AcessLevel = 0, FullName = "Mateus Santos"};
            var token = _tokenService.GenerateToken(user);

            return Task.FromResult(new
            {
                user,
                token
            }).Result;
        }

    }
}
