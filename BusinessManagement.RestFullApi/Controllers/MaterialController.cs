using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.MaterialDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MaterialController : Controller
    {
        private readonly IMaterialServices _materialServices;
        public MaterialController(IMaterialServices materialServices)
        {
            _materialServices = materialServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _materialServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddMaterial")]
        public async Task<IActionResult> Add(AddMaterialDto dto)
        {
            var addedEntity = await _materialServices.AddMaterialAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateMaterialDto dto, int id)
        {
            var updatedEntity = await _materialServices.UpdateMaterialAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _materialServices.DeleteMaterialAsync(id);
            return NoContent();
        }
    }
}
