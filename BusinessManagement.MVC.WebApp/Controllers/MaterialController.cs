using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.MaterialDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialServices _materialServices;

        public MaterialController(IMaterialServices materialServices)
        {
            _materialServices = materialServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _materialServices.GetAllMaterialsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddMaterial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterial(AddMaterialDto addMaterialDto)
        {
            await _materialServices.AddMaterialAsync(addMaterialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMaterial(int id)
        {
            await _materialServices.DeleteMaterialAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMaterial(int id)
        {
            var values = await _materialServices.GetAllMaterialsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateMaterialDto
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMaterial(UpdateMaterialDto updateMaterialDto)
        {
            await _materialServices.UpdateMaterialAsync(updateMaterialDto, updateMaterialDto.Id);
            return RedirectToAction("Index");
        }
    }
}
