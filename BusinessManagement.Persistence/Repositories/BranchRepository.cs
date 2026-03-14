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

        public async Task<AddBranchDto> AddBranchAsync(AddBranchDto addBranchDto)
        {
            var branch = new Branch
            {
                Name = addBranchDto.Name,
                Code = addBranchDto.Code,
                PhoneNumber = addBranchDto.PhoneNumber,
                Address = addBranchDto.Address,
                CreateDate = addBranchDto.CreateDate
            };
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return addBranchDto;

        }

        public Task DeleteBranchAsync(int id)
        {
            var branch = _context.Branches.Find(id);
            if(branch == null || branch.IsDeleted)
            {
                throw new KeyNotFoundException($"Şube bulunamadı Şube ID = {id}  (404)");
            }
            if (branch != null)
            {
                branch.IsDeleted = true;
                _context.Branches.Update(branch);
                return _context.SaveChangesAsync();

            }
            return Task.CompletedTask;

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

        public async Task<UpdateBranchDto> UpdateBranchAsync(UpdateBranchDto updateBranchDto, int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null || branch.IsDeleted)
            {
                throw new KeyNotFoundException($"Şube bulunamadı Şube ID = {id}  (404)");
            }
            var updatedBranch = new Branch
            {
                Id = id,
                Name = updateBranchDto.Name,
                Code = updateBranchDto.Code,
                PhoneNumber = updateBranchDto.PhoneNumber,
                Address = updateBranchDto.Address,
                CreateDate = branch.CreateDate,
                IsDeleted = branch.IsDeleted
            };
            _context.Entry(branch).CurrentValues.SetValues(updatedBranch);  // Mevcut varlık üzerinde güncellenmiş değerleri ayarla 
            await _context.SaveChangesAsync();
            return updateBranchDto;
        }
    }
}
