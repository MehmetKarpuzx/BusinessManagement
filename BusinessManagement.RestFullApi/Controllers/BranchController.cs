using BusinessManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : Controller
    {
        private readonly IBranchServices _branchServices;
        public BranchController(IBranchServices branchServices)
        {
            _branchServices = branchServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _branchServices.GetAllBranchesAsync();
            return Ok(branches);
        }
     
    }
}
