using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPI_Core_Proj.BLL;
using WebAPI_Core_Proj.Filters;
using WebAPI_Core_Proj.Models.ViewModels;

namespace WebAPI_Core_Proj.Controllers
{
    [Route("api/[controller]")]
    public class TestController
    {
        private TestService _TestService;

        public TestController(IOptions<ConfigViewModel> _Config)
        {
            _TestService = new TestService(_Config);
        }

        [HttpPost]
        [Route("TestQuery")]
        public void TestQuery()
        {
            var result = _TestService.QueryTestObject();
        }
    }
}
