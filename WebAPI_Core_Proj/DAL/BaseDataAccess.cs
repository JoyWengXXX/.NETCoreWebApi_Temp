using Microsoft.Extensions.Options;
using WebAPI_Core_Proj.Models.ViewModels;

namespace WebAPI_Core_Proj.DAL
{
    public class BaseDataAccess
    {
        protected static ConfigModel proj_Config { get; set; }

        public BaseDataAccess(IOptions<ConfigModel> _Config)
        {
            proj_Config = _Config.Value;
        }
    }
}
