using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.SupplierDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierServices _supplierServices;
        public SupplierController(ISupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _supplierServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> Add(AddSupplierDto dto)
        {
            var addedEntity = await _supplierServices.AddSupplierAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateSupplierDto dto, int id)
        {
            var updatedEntity = await _supplierServices.UpdateSupplierAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _supplierServices.DeleteSupplierAsync(id);
            return NoContent();
        }
    }
}
