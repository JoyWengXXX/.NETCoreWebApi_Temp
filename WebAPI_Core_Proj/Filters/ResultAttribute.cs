﻿using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Filters;
using WebAPI_Core_Proj.Models.ViewModels;

namespace WebAPI_Core_Proj.Filters
{
    public class ResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                return;
            }

            var ignoreResult1 = actionExecutedContext.ActionContext.ActionDescriptor.GetCustomAttributes<IgnoreResultAttribute>().FirstOrDefault();
            var ignoreResult2 = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<IgnoreResultAttribute>().FirstOrDefault();
            if (ignoreResult1 != null || ignoreResult2 != null)
            {
                return;
            }

            var objectContent = actionExecutedContext.Response.Content as ObjectContent;

            var data = objectContent?.Value;

            var result = new ResultViewModel
            {
                success = true,
                data = data
            };

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result);
        }
    }
}