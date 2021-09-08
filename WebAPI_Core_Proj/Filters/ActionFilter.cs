using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebAPI_Core_Proj.Filters
{
    public class ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}
