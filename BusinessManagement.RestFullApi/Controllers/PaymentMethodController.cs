using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.PaymentMethodDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodServices _paymentMethodServices;
        public PaymentMethodController(IPaymentMethodServices paymentMethodServices)
        {
            _paymentMethodServices = paymentMethodServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _paymentMethodServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddPaymentMethod")]
        public async Task<IActionResult> Add(AddPaymentMethodDto dto)
        {
            var addedEntity = await _paymentMethodServices.AddPaymentMethodAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdatePaymentMethodDto dto, int id)
        {
            var updatedEntity = await _paymentMethodServices.UpdatePaymentMethodAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentMethodServices.DeletePaymentMethodAsync(id);
            return NoContent();
        }
    }
}
