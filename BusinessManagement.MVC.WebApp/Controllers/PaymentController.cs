using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.PaymentDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentServices _paymentServices;
        private readonly ILoadDropdownServices _loadDropdownServices;

        public PaymentController(IPaymentServices paymentServices, ILoadDropdownServices loadDropdownServices)
        {
            _paymentServices = paymentServices;
            _loadDropdownServices = loadDropdownServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _paymentServices.GetAllPaymentsAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddPayment()
        {
            ViewBag.Orders = await _loadDropdownServices.GetOrdersSelectListAsync();
            ViewBag.PaymentMethods = await _loadDropdownServices.GetPaymentMethodsSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(AddPaymentDto addPaymentDto)
        {
            await _paymentServices.AddPaymentAsync(addPaymentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentServices.DeletePaymentAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePayment(int id)
        {
            var values = await _paymentServices.GetAllPaymentsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdatePaymentDto
            {
                Id = value.Id,
                OrderId = value.OrderId,
                PaymentMethodId = value.PaymentMethodId,
                Amount = value.Amount,
                PaymentDate = value.PaymentDate,
                Description = value.Description
            };

            ViewBag.Orders = await _loadDropdownServices.GetOrdersSelectListAsync();
            ViewBag.PaymentMethods = await _loadDropdownServices.GetPaymentMethodsSelectListAsync();
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePayment(UpdatePaymentDto updatePaymentDto)
        {
            await _paymentServices.UpdatePaymentAsync(updatePaymentDto, updatePaymentDto.Id);
            return RedirectToAction("Index");
        }
    }
}
