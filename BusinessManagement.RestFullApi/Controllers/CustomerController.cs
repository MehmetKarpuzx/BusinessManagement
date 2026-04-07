using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.CustomerDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _customerServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> Add(AddCustomerDto dto)
        {
            var addedEntity = await _customerServices.AddAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateCustomerDto dto, int id)
        {
            var updatedEntity = await _customerServices.UpdateAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
