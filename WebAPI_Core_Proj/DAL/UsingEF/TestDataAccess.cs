using DataAccessLayer_Entity_Framwork;
using Microsoft.Extensions.Options;
using ProjectModels.Entities;
using ProjectModels.DTO;

namespace WebAPI_Core_Proj.DAL.UsingEF
{
    public class TestDataAccess
    {
        private ProjectConfigDTO proj_Config = new ProjectConfigDTO();

        public TestDataAccess(IOptions<ProjectConfigDTO> _Config)
        {
            //專案參數
            proj_Config = _Config.Value;
        }

        public Test GetTestQuery(Test entityModel)
        {
            return new Test();
        }
    }
}
