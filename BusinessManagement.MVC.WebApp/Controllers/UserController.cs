using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ILoadDropdownServices _loadDropdownServices;

        public UserController(IUserServices userServices, ILoadDropdownServices loadDropdownServices)
        {
            _userServices = userServices;
            _loadDropdownServices = loadDropdownServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userServices.GetAllUsersAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            ViewBag.Roles = await _loadDropdownServices.GetRolesSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDto addUserDto)
        {
            await _userServices.AddUserAsync(addUserDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userServices.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var values = await _userServices.GetAllUsersAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateUserDto
            {
                Id = value.Id,
                Name = value.Name,
                Surname = value.Surname,
                Username = value.Username,
                RolId = value.RolId,
                IsActive = value.IsActive
                // We are not passing Password back to the view for security. Can be updated if needed.
            };

            ViewBag.Roles = await _loadDropdownServices.GetRolesSelectListAsync();
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            await _userServices.UpdateUserAsync(updateUserDto, updateUserDto.Id);
            return RedirectToAction("Index");
        }
    }
}
