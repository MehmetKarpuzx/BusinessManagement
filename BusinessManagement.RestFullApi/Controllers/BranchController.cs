using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.BranchDTOs;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BranchController : Controller
    {
        private readonly IBranchServices _branchServices;
        public BranchController(IBranchServices branchServices)
        {
            _branchServices = branchServices;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _branchServices.GetAllBranchesAsync();
            return Ok(branches);
        }
        [HttpPost("AddBranch")]
        public async Task<IActionResult> Add(AddBranchDto dto)
        {
            var addedBranch = await _branchServices.AddBranchAsync(dto);
            return Ok(addedBranch);

        }
        [HttpPut("Update {id}")]
        public async Task<IActionResult> Update( UpdateBranchDto dto, int id)
        {
            var updatedBranch = await _branchServices.UpdateBranchAsync(dto, id);
            return Ok(updatedBranch);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _branchServices.DeleteBranchAsync(id);
            return NoContent();
        }
    }
}
