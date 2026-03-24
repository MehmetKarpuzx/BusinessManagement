using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.PaymentMethodDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodServices _paymentMethodServices;

        public PaymentMethodController(IPaymentMethodServices paymentMethodServices)
        {
            _paymentMethodServices = paymentMethodServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _paymentMethodServices.GetAllPaymentMethodsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPaymentMethod()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymentMethod(AddPaymentMethodDto addPaymentMethodDto)
        {
            await _paymentMethodServices.AddPaymentMethodAsync(addPaymentMethodDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            await _paymentMethodServices.DeletePaymentMethodAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePaymentMethod(int id)
        {
            var values = await _paymentMethodServices.GetAllPaymentMethodsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdatePaymentMethodDto
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePaymentMethod(UpdatePaymentMethodDto updatePaymentMethodDto)
        {
            await _paymentMethodServices.UpdatePaymentMethodAsync(updatePaymentMethodDto, updatePaymentMethodDto.Id);
            return RedirectToAction("Index");
        }
    }
}
