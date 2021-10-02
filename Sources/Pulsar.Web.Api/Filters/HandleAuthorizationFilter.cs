using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Filters
{
    public class HandleAuthorizationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null && context.Exception is PulsarException pi)
            {
                if (pi.ErrorCode == PulsarErrorCode.Forbidden)
                {
                    context.ExceptionHandled = true;
                    context.Result = new ForbidResult();
                }
                else if (pi.ErrorCode == PulsarErrorCode.BadRequest)
                {
                    context.ExceptionHandled = true;
                    context.Result = new JsonResult(new { pi.Data, pi.ErrorCode, pi.Message, pi.StackTrace })
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                else if (pi.ErrorCode == PulsarErrorCode.NotFound)
                {
                    context.ExceptionHandled = true;
                    context.Result = new JsonResult(new { Message = "Entidade com id informado não foi encontrada." })
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
