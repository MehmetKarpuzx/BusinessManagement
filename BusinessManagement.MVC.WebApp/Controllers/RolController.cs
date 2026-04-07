using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.RolDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolServices _rolServices;

        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _rolServices.GetAllRolsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRol(AddRolDto addRolDto)
        {
            await _rolServices.AddRolAsync(addRolDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRol(int id)
        {
            await _rolServices.DeleteRolAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRol(int id)
        {
            var values = await _rolServices.GetAllRolsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateRolDto
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                IsActive = value.IsActive
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRol(UpdateRolDto updateRolDto)
        {
            await _rolServices.UpdateRolAsync(updateRolDto, updateRolDto.Id);
            return RedirectToAction("Index");
        }
    }
}
