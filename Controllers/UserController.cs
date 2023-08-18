﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.User;
using TimeasyAPI.src.DTOs.User.Requests;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController: MainController
    {   

        private readonly IUserServices _userService;

        public UserController(  IUserServices userService)
        {
            _userService = userService;
        }


        [HttpPost("auth")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public async Task<IActionResult> Auth([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new AppException(GetModelErrors());
            }

            return Ok(await _userService.AuthAsync(request));
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {

            if (!ModelState.IsValid)
            {
                throw new AppException(GetModelErrors());
            }
    
            return Ok(await _userService.CreateRootUserAsync(request));
        }
    }
}
