using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebAPI_Core_Proj.Filters
{
    public class ResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}
