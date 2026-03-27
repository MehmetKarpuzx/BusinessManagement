using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.MaterialProcurementDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MaterialProcurementController : Controller
    {
        private readonly IMaterialProcurementServices _materialProcurementServices;
        public MaterialProcurementController(IMaterialProcurementServices materialProcurementServices)
        {
            _materialProcurementServices = materialProcurementServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _materialProcurementServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddMaterialProcurement")]
        public async Task<IActionResult> Add(AddMaterialProcurementDto dto)
        {
            var addedEntity = await _materialProcurementServices.AddMaterialProcurementAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateMaterialProcurementDto dto, int id)
        {
            var updatedEntity = await _materialProcurementServices.UpdateMaterialProcurementAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _materialProcurementServices.DeleteMaterialProcurementAsync(id);
            return NoContent();
        }
    }
}
