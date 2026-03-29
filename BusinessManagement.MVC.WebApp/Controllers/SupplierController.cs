using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.SupplierDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierServices _supplierServices;

        public SupplierController(ISupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _supplierServices.GetAllSuppliersAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(AddSupplierDto addSupplierDto)
        {
            await _supplierServices.AddSupplierAsync(addSupplierDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierServices.DeleteSupplierAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSupplier(int id)
        {
            var values = await _supplierServices.GetAllSuppliersAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateSupplierDto
            {
                Id = value.Id,
                Name = value.Name,
                PhoneNumber = value.PhoneNumber,
                Email = value.Email,
                Adress = value.Adress,
                Description = value.Description,
                IsDeleted = value.IsDeleted
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierDto updateSupplierDto)
        {
            await _supplierServices.UpdateSupplierAsync(updateSupplierDto, updateSupplierDto.Id);
            return RedirectToAction("Index");
        }
    }
}
