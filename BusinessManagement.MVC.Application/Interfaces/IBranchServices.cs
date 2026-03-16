using BusinessManagement.MVC.DTO.BranchDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IBranchServices
    {
        Task<List<ResultBranchDto>> GetAllBranchesAsync();
        Task<AddBranchDto> AddBranchAsync(AddBranchDto addBranchDto);
        Task<UpdateBranchDto> UpdateBranchAsync(UpdateBranchDto updateBranchDto, int id);
        Task DeleteBranchAsync(int id);
    }
}
