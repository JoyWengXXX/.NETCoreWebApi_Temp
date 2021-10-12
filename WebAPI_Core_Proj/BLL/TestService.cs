using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectModels.Entities;
using ProjectModels.DTO;
//using WebAPI_Core_Proj.DAL.UsingDapper;
using WebAPI_Core_Proj.DAL.UsingEF;
using WebAPI_Core_Proj.Filters;

namespace WebAPI_Core_Proj.BLL
{
    public class TestService
    {
        private TestDataAccess _TestDAO;
        private ILogger<ExceptionFilter> _logger;

        public TestService(IOptions<ProjectConfigDTO> _Config, ILogger<ExceptionFilter> logger)
        {
            _TestDAO = new TestDataAccess(_Config);
            _logger = logger;
        }

        public Test QueryTestObject()
        {
            Test returnObj = new Test()
            {
                Data = "TData004",
                Id = "T004"
            };

            _logger.LogInformation("這是一則LOG");

            var result = _TestDAO.GetTestQuery(returnObj);

            return result;
        } 
    }
}
