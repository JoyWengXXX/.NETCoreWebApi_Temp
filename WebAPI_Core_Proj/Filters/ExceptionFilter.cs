using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace WebAPI_Core_Proj.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
            _logger.LogError(context.Exception.Message);
        }
    }
}
