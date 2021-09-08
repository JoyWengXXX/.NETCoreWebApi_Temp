using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebAPI_Core_Proj.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }
    }
}
