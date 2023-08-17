﻿using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.DTOs.Institute.Request;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.Controllers
{
    [Route("api/[controller]")]
    public class InstituteController : ControllerBase
    {
        private readonly IInstituteServices _instituteServices;
        private readonly IIntervalServices _intervalServices;
        public InstituteController(IInstituteServices instituteServices, IIntervalServices intervalServices)
        {
            _instituteServices = instituteServices;
            _intervalServices = intervalServices;
        }


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

        [HttpGet]
        public async Task<IActionResult> FindById(string instituteId)
        {
            return Ok(await _instituteServices.GetById(instituteId));
        }

        [HttpPatch("intervals")]
        public async Task<IActionResult> AddIntervals([FromBody] AddIntervalsRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors());
            }

            await _intervalServices.AddIntervalsAsync(request);
            return NoContent();
        }

        [HttpDelete("intervals")]
        public async Task<IActionResult> RemoveInterval(string intervalId)
        {
            await _intervalServices.DeleteAsync(intervalId);
            return NoContent();
        }

        private string GetModelErrors()
        {
            var validationErrors = ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)
                                            .ToList();

            return string.Join(" ", validationErrors);
        }

    }
}
