using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.BranchDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task<List<ResponseBranchDto>> GetAllBranchesAsync();
        Task<AddBranchDto> AddBranchAsync(AddBranchDto addBranchDto);
        Task<UpdateBranchDto> UpdateBranchAsync(UpdateBranchDto updateBranchDto,int id);
         Task DeleteBranchAsync(int id);
    }
}
