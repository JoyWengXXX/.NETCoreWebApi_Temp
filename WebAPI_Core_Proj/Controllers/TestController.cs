using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectModels.ViewModels;
using WebAPI_Core_Proj.BLL;
using WebAPI_Core_Proj.Filters;

namespace WebAPI_Core_Proj.Controllers
{
    [Route("api/[controller]")]
    public class TestController
    {
        private TestService _TestService;
        private ILogger<ExceptionFilter> _logger;

        public TestController(IOptions<ConfigViewModel> _Config, ILogger<ExceptionFilter> logger)
        {
            _TestService = new TestService(_Config, logger);
            _logger = logger;
        }

        [HttpPost]
        [Route("TestQuery")]
        public void TestQuery()
        {
            var result = _TestService.QueryTestObject();
        }
    }
}
