using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectModels.DTO;

namespace WebAPI_Core_Proj.BLL
{
    public class BaseService
    {
        protected readonly ILogger _logger;
        protected readonly IOptions<ProjectConfigDTO> _config;

        public BaseService(IOptions<ProjectConfigDTO> config, ILogger<BaseService> logger)
        {
            _config = config;
            _logger = logger;
        }
    }
}
