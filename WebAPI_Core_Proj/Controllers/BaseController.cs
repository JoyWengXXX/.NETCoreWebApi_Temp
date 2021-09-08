using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Web.Http.Filters;
using WebAPI_Core_Proj.Models.ViewModels;

namespace WebAPI_Core_Proj.Controllers
{
    [ApiController]
    //[ExceptionFilter]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly IOptions<ConfigViewModel> _config;

        public BaseController(IOptions<ConfigViewModel> config, ILogger<BaseController> logger)
        {
            _config = config;
            _logger = logger;
        }
    }
}
