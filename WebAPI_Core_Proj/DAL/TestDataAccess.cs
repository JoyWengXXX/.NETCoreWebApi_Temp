using Microsoft.Extensions.Options;
using WebAPI_Core_Proj.Models.ViewModels;
using WebAPI_Core_Proj.Models;
using DataAccessLayer;

namespace WebAPI_Core_Proj.DAL
{
    public class TestDataAccess : BaseDataAccess
    {
        public TestDataAccess(IOptions<ConfigModel> _Config) : base(_Config) { }

        public GenericRepository<TestModel> TestDAO = new GenericRepository<TestModel>(typeof(TestModel).Name, proj_Config.connectString);
    }
}
