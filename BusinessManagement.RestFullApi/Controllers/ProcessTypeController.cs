using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.ProcessTypeDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProcessTypeController : Controller
    {
        private readonly IProcessTypeServices _processTypeServices;
        public ProcessTypeController(IProcessTypeServices processTypeServices)
        {
            _processTypeServices = processTypeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _processTypeServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProcessTypeDto dto)
        {
            var addedEntity = await _processTypeServices.AddProcessTypeAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateProcessTypeDto dto, int id)
        {
            var updatedEntity = await _processTypeServices.UpdateProcessTypeAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _processTypeServices.DeleteProcessTypeAsync(id);
            return NoContent();
        }
    }
}
