using DataAccessLayer_Entity_Framwork;
using Microsoft.Extensions.Options;
using ProjectModels.Entities;
using ProjectModels.ViewModels;

namespace WebAPI_Core_Proj.DAL.UsingEF
{
    public class TestDataAccess
    {
        private ConfigViewModel proj_Config = new ConfigViewModel();

        public TestDataAccess(IOptions<ConfigViewModel> _Config)
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
