using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.CustomerTypeDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class CustomerTypeController : Controller
    {
        private readonly ICustomerTypeServices _customerTypeServices;

        public CustomerTypeController(ICustomerTypeServices customerTypeServices)
        {
            _customerTypeServices = customerTypeServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _customerTypeServices.GetAllCustomerTypesAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomerType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerType(AddCustomerTypeDto addCustomerTypeDto)
        {
            await _customerTypeServices.AddCustomerTypeAsync(addCustomerTypeDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCustomerType(int id)
        {
            await _customerTypeServices.DeleteCustomerTypeAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomerType(int id)
        {
            var values = await _customerTypeServices.GetAllCustomerTypesAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateCustomerTypeDto
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomerType(UpdateCustomerTypeDto updateCustomerTypeDto)
        {
            await _customerTypeServices.UpdateCustomerTypeAsync(updateCustomerTypeDto, updateCustomerTypeDto.Id);
            return RedirectToAction("Index");
        }
    }
}
