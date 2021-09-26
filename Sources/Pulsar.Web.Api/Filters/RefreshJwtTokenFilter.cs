using Microsoft.AspNetCore.Mvc.Filters;
using Pulsar.Web.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Filters
{
    public class RefreshJwtTokenFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var token = RegenerateToken(context);
            if (token != null)
            {
                context.HttpContext.Response.Headers.Add("Set-Authorization", token);
            }
        }

        private string RegenerateToken(ActionExecutedContext context)
        {
            var controller = context.Controller as PulsarController;
            if (controller == null)
                return null;

            var user = controller.CurrentUser;
            if (user == null)
                return null;

            return controller.CreateToken(new Models.UserClaims()
            {
                Id = user.Id,
                Role = $"{(user.RedeEstabelecimentoId.HasValue ? user.RedeEstabelecimentoId.ToString() : "_")}/{(user.EstabelecimentoId.HasValue ? user.EstabelecimentoId.ToString() : "_")}"
            });
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
