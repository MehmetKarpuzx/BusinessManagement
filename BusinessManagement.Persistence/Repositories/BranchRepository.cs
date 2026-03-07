using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.BranchDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.Persistence.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly BusinessManagementDbContext _context;
        public BranchRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseBranchDto>> GetAllBranchesAsync()
        {
            var branches = await _context.Branches
                .Select(b => new ResponseBranchDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Code = b.Code,
                    PhoneNumber = b.PhoneNumber,
                    Address = b.Address,
                    CreateDate = b.CreateDate,
                    IsDeleted = b.IsDeleted
                })
                .Where(b => !b.IsDeleted)
                .OrderBy(b => b.Name)
                .ToListAsync();
            return branches;    
        }
    }
}
