using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TimeasyAPI.Controllers
{
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public class MainController : ControllerBase
    {

        protected string GetModelErrors()
        {
            var validationErrors = ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)
                                            .ToList();

            return string.Join(" ", validationErrors);
        }
    }
}
