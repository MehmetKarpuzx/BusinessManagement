using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.RolDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _rolServices.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("AddRol")]
        public async Task<IActionResult> AddRol(AddRolDto dto)
        {
            var result = await _rolServices.AddAsync(dto);
            return Ok(result);
        }

        [HttpPut("UpdateRol/{id}")]
        public async Task<IActionResult> UpdateRol(int id, UpdateRolDto dto)
        {
            var result = await _rolServices.UpdateAsync(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("DeleteRol/{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            await _rolServices.DeleteAsync(id);
            return Ok();
        }
    }
}
