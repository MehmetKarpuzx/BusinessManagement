using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.CustomerTypeDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerTypeController : Controller
    {
        private readonly ICustomerTypeServices _customerTypeServices;
        public CustomerTypeController(ICustomerTypeServices customerTypeServices)
        {
            _customerTypeServices = customerTypeServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _customerTypeServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddCustomerType")]
        public async Task<IActionResult> Add(AddCustomerTypeDto dto)
        {
            var addedEntity = await _customerTypeServices.AddCustomerTypeAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateCustomerTypeDto dto, int id)
        {
            var updatedEntity = await _customerTypeServices.UpdateCustomerTypeAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerTypeServices.DeleteCustomerTypeAsync(id);
            return NoContent();
        }
    }
}
