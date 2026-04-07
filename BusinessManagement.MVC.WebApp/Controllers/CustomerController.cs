using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.CustomerDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _customerServices;
        private readonly ILoadDropdownServices _loadDropdownServices;

        public CustomerController(ICustomerServices customerServices, ILoadDropdownServices loadDropdownServices)
        {
            _customerServices = customerServices;
            _loadDropdownServices = loadDropdownServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _customerServices.GetAllCustomersAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            ViewBag.CustomerTypes = await _loadDropdownServices.GetCustomerTypesSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDto addCustomerDto)
        {
            await _customerServices.AddCustomerAsync(addCustomerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerServices.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var values = await _customerServices.GetAllCustomersAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateCustomerDto
            {
                Id = value.Id,
                Name = value.Name,
                Surname = value.Surname,
                PhoneNumber = value.PhoneNumber,
                Email = value.Email,
                Adress = value.Adress,
                City = value.City,
                RegistrationNumber = value.RegistrationNumber,
                Tckn = value.Tckn,
                TaxNumber = value.TaxNumber,
                TaxOffice = value.TaxOffice,
                Description = value.Description,
                CustomerTypeId = value.CustomerTypeId,
                IsDeleted = value.IsDeleted
            };

            ViewBag.CustomerTypes = await _loadDropdownServices.GetCustomerTypesSelectListAsync();
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            await _customerServices.UpdateCustomerAsync(updateCustomerDto, updateCustomerDto.Id);
            return RedirectToAction("Index");
        }
    }
}
