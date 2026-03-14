using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.BranchDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Services
{
    public class BranchServices : IBranchServices
    {
        private readonly IBranchRepository _branchRepository;
        public BranchServices(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<AddBranchDto> AddBranchAsync(AddBranchDto addBranchDto)
        {
            return await _branchRepository.AddBranchAsync(addBranchDto);
        }

        public Task DeleteBranchAsync(int id)
        {
            return _branchRepository.DeleteBranchAsync(id);
        }

        public async Task<List<ResponseBranchDto>> GetAllBranchesAsync()
        {
           return await _branchRepository.GetAllBranchesAsync();
        }

        public async Task<UpdateBranchDto> UpdateBranchAsync(UpdateBranchDto updateBranchDto, int id)
        {
            return await _branchRepository.UpdateBranchAsync(updateBranchDto, id);
        }
    }
}
