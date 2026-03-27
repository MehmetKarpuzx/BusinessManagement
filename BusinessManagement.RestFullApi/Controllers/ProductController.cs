using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _productServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> Add(AddProductDto dto)
        {
            var addedEntity = await _productServices.AddProductAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateProductDto dto, int id)
        {
            var updatedEntity = await _productServices.UpdateProductAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productServices.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
