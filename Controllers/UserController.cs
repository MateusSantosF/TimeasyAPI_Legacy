using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.Models.Core;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {   
        private readonly ILogger<UserController> _logger;
        private readonly ITokenService _tokenService;
        private readonly IUserServices _userService;

        public UserController(ILogger<UserController> logger, ITokenService tokenService, IUserServices userService = null)
        {
            _logger = logger;
            _tokenService = tokenService;
            _userService = userService;
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

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {

            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values.SelectMany(v => v.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToList();

                throw new AppException(string.Join(" ", validationErrors));
            }
            var result = await _userService.CreateRootUserAsync(request);
            return Ok(result);
        }

    }
}
