using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.TransferDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransferController : Controller
    {
        private readonly ITransferServices _transferServices;
        public TransferController(ITransferServices transferServices)
        {
            _transferServices = transferServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _transferServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTransferDto dto)
        {
            var addedEntity = await _transferServices.AddTransferAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateTransferDto dto, int id)
        {
            var updatedEntity = await _transferServices.UpdateTransferAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _transferServices.DeleteTransferAsync(id);
            return NoContent();
        }
    }
}
