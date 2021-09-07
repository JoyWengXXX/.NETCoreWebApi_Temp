using System;
using System.Net.Http;
using System.Web.Http.Filters;
using WebAPI_Core_Proj.Models.ViewModels;

namespace WebAPI_Core_Proj.Filters
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var result = new ResultViewModel
            {
                success = false,
                msg = actionExecutedContext.Exception.Message
            };

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result);
        }
    }
}
