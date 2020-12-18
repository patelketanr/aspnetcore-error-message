using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Business;
using App.Core.BusinessExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCore.Boilerplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            HttpStatusCode code = HttpStatusCode.InternalServerError;
            List<object> errors = null;
            if (context.Error.GetType().Name == "BusinessRuleException")
            {
                var businessRuleException = (BusinessRuleException)context.Error;
                code = businessRuleException.StatusCode;
                errors = businessRuleException.Errors;
            }

            this.HttpContext.Response.StatusCode = (int)code;
            return new ObjectResult (
                new {
                    Title = context.Error.Message,
                    Errors = errors,
                    Detail = (webHostEnvironment.EnvironmentName =="Development") ? context.Error.StackTrace :string.Empty
                    });
        }
    }
}
