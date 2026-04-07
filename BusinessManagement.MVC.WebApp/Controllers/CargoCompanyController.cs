using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.CargoCompanyDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class CargoCompanyController : Controller
    {
        private readonly ICargoCompanyServices _cargoCompanyServices;

        public CargoCompanyController(ICargoCompanyServices cargoCompanyServices)
        {
            _cargoCompanyServices = cargoCompanyServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _cargoCompanyServices.GetAllCargoCompaniesAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCargoCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCargoCompany(AddCargoCompanyDto addCargoCompanyDto)
        {
            await _cargoCompanyServices.AddCargoCompanyAsync(addCargoCompanyDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyServices.DeleteCargoCompanyAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var values = await _cargoCompanyServices.GetAllCargoCompaniesAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateCargoCompanyDto
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyServices.UpdateCargoCompanyAsync(updateCargoCompanyDto, updateCargoCompanyDto.Id);
            return RedirectToAction("Index");
        }
    }
}
