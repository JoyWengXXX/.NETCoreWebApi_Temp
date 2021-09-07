using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPI_Core_Proj.BLL;
using WebAPI_Core_Proj.Filters;
using WebAPI_Core_Proj.Models.ViewModels;

namespace WebAPI_Core_Proj.Controllers
{
    [Result]
    [Exception]
    [Route("api/[controller]")]
    public class TestController : BaseController
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
            bool result = _TestService.QueryTestObject();
            if (result)
            {

            }
            else
            {

            }
        }
    }
}
