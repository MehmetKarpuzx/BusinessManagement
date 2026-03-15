using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.UnitDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UnitController : Controller
    {
        private readonly IUnitServices _unitServices;
        public UnitController(IUnitServices unitServices)
        {
            _unitServices = unitServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unitServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUnitDto dto)
        {
            var addedEntity = await _unitServices.AddUnitAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateUnitDto dto, int id)
        {
            var updatedEntity = await _unitServices.UpdateUnitAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitServices.DeleteUnitAsync(id);
            return NoContent();
        }
    }
}
