using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPI_Core_Proj.Models.ViewModels;

namespace WebAPI_Core_Proj.BLL
{
    public class BaseService
    {
        protected readonly ILogger _logger;
        protected readonly IOptions<ConfigViewModel> _config;

        public BaseService(IOptions<ConfigViewModel> config, ILogger<BaseService> logger)
        {
            _config = config;
            _logger = logger;
        }
    }
}
