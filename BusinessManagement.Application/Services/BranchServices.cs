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
        public async Task<List<ResponseBranchDto>> GetAllBranchesAsync()
        {
            var branches = await _branchRepository.GetAllBranchesAsync();
            return branches;
        }
    }
}
