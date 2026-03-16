using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.BranchDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchServices _branchServices;

        public BranchController(IBranchServices branchServices)
        {
            _branchServices = branchServices;
        }

        public async Task<IActionResult> Index()
        {
            var branches = await _branchServices.GetAllBranchesAsync();
            return View(branches);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBranchDto addBranchDto)
        {
            if (ModelState.IsValid)
            {
                await _branchServices.AddBranchAsync(addBranchDto);
                return RedirectToAction(nameof(Index));
            }
            return View(addBranchDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            // We need the specific branch to update. 
            // In a better scenario, there would be a GetByIdAsync method.
            // Since we don't have it, we'll fetch all and filter, or we can just send an empty DTO with the ID to the view.
            var branches = await _branchServices.GetAllBranchesAsync();
            var branch = branches.Find(x => x.Id == id);
            
            if (branch == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateBranchDto
            {
                Id = branch.Id,
                Name = branch.Name,
                Code = branch.Code,
                PhoneNumber = branch.PhoneNumber,
                Address = branch.Address
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBranchDto updateBranchDto)
        {
            if (ModelState.IsValid)
            {
                await _branchServices.UpdateBranchAsync(updateBranchDto, updateBranchDto.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(updateBranchDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _branchServices.DeleteBranchAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
