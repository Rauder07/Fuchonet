using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fuchonet.Services.Interface;

namespace Fuchonet.FuchonetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAgrementController : ControllerBase
    {
        IServiceAgrementService _serviceAgrementService { get; set; }

        public ServiceAgrementController(IServiceAgrementService serviceAgrementService)
        {
            _serviceAgrementService = serviceAgrementService;
        }

        
        [HttpGet]
        [Route("Count")]
        public async Task<ActionResult<int>>  CountServicesAgrement(string status_service)
        {
            if (!String.IsNullOrEmpty(status_service))
            {
                var response = await _serviceAgrementService.CountServiceAgrementByService(status_service);
                return response;
            }
            else
            {
                return NotFound();
            }
        }
    }
}

