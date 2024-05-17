using Fuchonet.Dto.Response;
using Fuchonet.Dto.Request;
using Fuchonet.FuchonetAPI.Utility;
using Fuchonet.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Fuchonet.Services.Implementation;
using Fuchonet.Repositories.Implementation;
using Fuchonet.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fuchonet.FuchonetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoriesController : ControllerBase
    {
        IServiceCategoryService _serviceCategory { get; set; }

        public ServiceCategoriesController(IServiceCategoryService serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }

        [HttpGet]
        public async Task<List<ServiceCategoryDTO>> Get([FromQuery]PaginationParams request)
        {
            var result = await _serviceCategory.GetAll();
            await HttpContext.InsertarPaginationHeader(result.AsQueryable(), request);
            var resultDTO = result.AsQueryable().ProjectToType<ServiceCategoryDTO>();
            return resultDTO.ToList(); 
        }

        [HttpGet]
        [Route("h/")]
        public async Task<List<ServiceCategoryDTO>> Getdata([FromQuery] PaginationParams request)
        {
            var result = await _serviceCategory.GetAll();
            await HttpContext.InsertarPaginationHeader(result.AsQueryable(), request);
            var resultDTO = result.AsQueryable().ProjectToType<ServiceCategoryDTO>();
            return resultDTO.ToList();
        }

        // POST api/<ServiceCategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServiceCategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceCategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
