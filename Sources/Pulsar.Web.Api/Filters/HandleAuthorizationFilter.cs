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
            if (context.Exception != null && context.Exception is PulsarException pi && pi.ErrorCode == PulsarErrorCode.Forbidden)
            {
                context.ExceptionHandled = true;
                context.Result = new ForbidResult();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
