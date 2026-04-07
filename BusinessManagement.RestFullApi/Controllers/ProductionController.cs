using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.ProductionDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductionController : Controller
    {
        private readonly IProductionServices _productionServices;
        public ProductionController(IProductionServices productionServices)
        {
            _productionServices = productionServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _productionServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddProduction")]
        public async Task<IActionResult> Add(AddProductionDto dto)
        {
            var addedEntity = await _productionServices.AddProductionAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateProductionDto dto, int id)
        {
            var updatedEntity = await _productionServices.UpdateProductionAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productionServices.DeleteProductionAsync(id);
            return NoContent();
        }
    }
}
