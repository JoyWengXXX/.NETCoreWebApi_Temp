using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebAPI_Core_Proj.Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}
