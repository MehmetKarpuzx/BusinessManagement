using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.ProcessTypeDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class ProcessTypeController : Controller
    {
        private readonly IProcessTypeServices _processTypeServices;

        public ProcessTypeController(IProcessTypeServices processTypeServices)
        {
            _processTypeServices = processTypeServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _processTypeServices.GetAllProcessTypesAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProcessType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProcessType(AddProcessTypeDto addProcessTypeDto)
        {
            await _processTypeServices.AddProcessTypeAsync(addProcessTypeDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProcessType(int id)
        {
            await _processTypeServices.DeleteProcessTypeAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProcessType(int id)
        {
            var values = await _processTypeServices.GetAllProcessTypesAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateProcessTypeDto
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProcessType(UpdateProcessTypeDto updateProcessTypeDto)
        {
            await _processTypeServices.UpdateProcessTypeAsync(updateProcessTypeDto, updateProcessTypeDto.Id);
            return RedirectToAction("Index");
        }
    }
}
