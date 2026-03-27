using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.PaymentDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentServices _paymentServices;
        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _paymentServices.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("AddPayment")]
        public async Task<IActionResult> Add(AddPaymentDto dto)
        {
            var addedEntity = await _paymentServices.AddPaymentAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdatePaymentDto dto, int id)
        {
            var updatedEntity = await _paymentServices.UpdatePaymentAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentServices.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
