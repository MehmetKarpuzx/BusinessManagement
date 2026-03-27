using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.OrderDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _orderServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> Add(AddOrderDto dto)
        {
            var addedEntity = await _orderServices.AddOrderAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateOrderDto dto, int id)
        {
            var updatedEntity = await _orderServices.UpdateOrderAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderServices.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
