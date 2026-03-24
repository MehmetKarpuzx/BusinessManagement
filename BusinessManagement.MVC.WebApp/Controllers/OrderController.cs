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

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _orderServices.GetAllOrdersAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
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
                CargoCompanyId = value.CargoCompanyId,
                OrderDate = value.OrderDate,
                EmployeeId = value.EmployeeId,
                BranchId = value.BranchId,
                EstimatedDeliveryDate = value.EstimatedDeliveryDate,
                DeliveryDate = value.DeliveryDate,
                TotalAmount = value.TotalAmount,
                OrderStatus = value.OrderStatus,
                Description = value.Description
            };

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
