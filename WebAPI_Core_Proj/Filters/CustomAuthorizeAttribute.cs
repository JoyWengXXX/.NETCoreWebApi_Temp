using System.Web.Http.Filters;

namespace WebAPI_Core_Proj.Filters
{
    public class CustomAuthorizeAttribute : AuthorizationFilterAttribute
    {
        //protected readonly UserManager _userManager;
        //public CustomAuthorizeAttribute()
        //{
        //    _userManager = new UserManager();
        //}

        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    try
        //    {
        //        if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
        //        {
        //            return;
        //        }
        //        if (actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
        //        {
        //            return;
        //        }

        //        var user = _userManager.GetCurrentUser();
        //        if (user == null)
        //        {
        //            throw new CustomException("沒有權限。");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!(ex is CustomException))
        //        {
        //            ex = new CustomException("權限驗證異常。");
        //        }

        //        var result = new ResultViewModel
        //        {
        //            success = false,
        //            msg = ex.Message
        //        };
        //        actionContext.Response = actionContext.Request.CreateResponse(result);
        //    }
        //}
    }
}
