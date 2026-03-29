using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.UnitDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitServices _unitServices;

        public UnitController(IUnitServices unitServices)
        {
            _unitServices = unitServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _unitServices.GetAllUnitsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddUnit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUnit(AddUnitDto addUnitDto)
        {
            await _unitServices.AddUnitAsync(addUnitDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUnit(int id)
        {
            await _unitServices.DeleteUnitAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUnit(int id)
        {
            var values = await _unitServices.GetAllUnitsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateUnitDto
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                IsDeleted = value.IsDeleted
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUnit(UpdateUnitDto updateUnitDto)
        {
            await _unitServices.UpdateUnitAsync(updateUnitDto, updateUnitDto.Id);
            return RedirectToAction("Index");
        }
    }
}
