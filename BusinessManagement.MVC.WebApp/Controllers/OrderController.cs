using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.OrderDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly ILoadDropdownServices _loadDropdownServices;

        public OrderController(IOrderServices orderServices, ILoadDropdownServices loadDropdownServices)
        {
            _orderServices = orderServices;
            _loadDropdownServices = loadDropdownServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _orderServices.GetAllOrdersAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrder()
        {
            ViewBag.Customers = await _loadDropdownServices.GetCustomersSelectListAsync();
            ViewBag.Branches = await _loadDropdownServices.GetBranchesSelectListAsync();
            ViewBag.Products = await _loadDropdownServices.GetProductsSelectListAsync();
            ViewBag.CargoCompanies = await _loadDropdownServices.GetCargoCompaniesSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderDto addOrderDto)
        {
            await _orderServices.AddOrderAsync(addOrderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderServices.DeleteOrderAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var values = await _orderServices.GetAllOrdersAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateOrderDto
            {
                Id = value.Id,
                CustomerId = value.CustomerId,
                BranchId = value.BranchId,
                ProductId = value.ProductId,
                Amount = value.Amount,
                TotalPrice = value.TotalPrice,
                OrderDate = value.OrderDate,
                OrderStatus = value.OrderStatus,
                CargoCompanyId = value.CargoCompanyId,
                CargoPrice = value.CargoPrice,
                CargoDescription = value.CargoDescription,
                DiscountPrice = value.DiscountPrice,
                DiscountDescription = value.DiscountDescription,
                PaymentReceived = value.PaymentReceived,
                RemainderPrice = value.RemainderPrice,
                Description = value.Description
            };

            ViewBag.Customers = await _loadDropdownServices.GetCustomersSelectListAsync();
            ViewBag.Branches = await _loadDropdownServices.GetBranchesSelectListAsync();
            ViewBag.Products = await _loadDropdownServices.GetProductsSelectListAsync();
            ViewBag.CargoCompanies = await _loadDropdownServices.GetCargoCompaniesSelectListAsync();
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            await _orderServices.UpdateOrderAsync(updateOrderDto, updateOrderDto.Id);
            return RedirectToAction("Index");
        }
    }
}
