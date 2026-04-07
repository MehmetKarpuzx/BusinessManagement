using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.WarehouseMovementDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WarehouseMovementController : Controller
    {
        private readonly IWarehouseMovementServices _warehouseMovementServices;
        public WarehouseMovementController(IWarehouseMovementServices warehouseMovementServices)
        {
            _warehouseMovementServices = warehouseMovementServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _warehouseMovementServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddWarehouseMovement")]
        public async Task<IActionResult> Add(AddWarehouseMovementDto dto)
        {
            var addedEntity = await _warehouseMovementServices.AddWarehouseMovementAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateWarehouseMovementDto dto, int id)
        {
            var updatedEntity = await _warehouseMovementServices.UpdateWarehouseMovementAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _warehouseMovementServices.DeleteWarehouseMovementAsync(id);
            return NoContent();
        }
    }
}
